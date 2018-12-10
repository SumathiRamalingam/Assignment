using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetCloneApp.ViewModel;



namespace TweetCloneApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        public ActionResult Profiler()
        {
            if (Session["UserID"] != null)
            {
                AssessmentEntities db = new AssessmentEntities();
                var objPerson = db.people.Find(Session["UserID"].ToString());
                return View("Profile", objPerson);
            }
            return RedirectToAction("Login");
        }

        public ActionResult SignOut()
        {           
                return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "user_id,passwod,fullname,email")] person person)
        {
            AssessmentEntities db = new AssessmentEntities();
            if (ModelState.IsValid)
            {
                person.active = true;
                person.joined = DateTime.Now;
                db.people.Add(person);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(person);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(person objUser)
        {
            if (ModelState.IsValid)
            {
                using (AssessmentEntities db = new AssessmentEntities())
                {
                    var obj = db.people.Where(a => a.user_id.Equals(objUser.user_id) && a.passwod.Equals(objUser.passwod)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.user_id.ToString();
                        Session["UserName"] = obj.fullname.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                TweetViewModel oTwt = new TweetViewModel();
                oTwt.objTweetList = GetTweetList();
                oTwt.tweetCount = oTwt.objTweetList.Count.ToString() ;

                string result =  GetFollowingList();
                oTwt.followingCount = result.Split(';')[0];
                oTwt.followersCount = result.Split(';')[1];                
                return View(oTwt);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public string GetFollowingList()
        {
            string res = string.Empty;
            int followingCount = 0;
            int followsCount = 0;
            AssessmentEntities db = new AssessmentEntities();
            var follows = db.followings.ToList();
            if (follows != null)
            {
                foreach (var item in follows)
                {
                    if (item.user_id == Session["UserID"].ToString())
                    {
                        followingCount++;
                    }
                    if (item.following_id == Session["UserID"].ToString())
                    {
                        followsCount++;
                    }
                }
            }
            return followingCount+";"+followsCount;
        }

        public List<tweet> GetTweetList()
        {
            List<tweet> res = new List<tweet>();
            AssessmentEntities db = new AssessmentEntities();
            var tweets = db.tweets.ToList();
            if (tweets != null)
            {
                foreach (var item in tweets)
                {
                    if (item.user_id == Session["UserID"].ToString())
                    {
                        res.Add(item);
                    }
                }
            }
            return res;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]      
        public ActionResult UserDashBoard([Bind(Include = "objTweet,objTweetList,objFollow")] TweetViewModel objTwt)
        {
            AssessmentEntities db = new AssessmentEntities();
            tweet objTweet = new tweet();
            following objFollow = new following();
            TweetViewModel oTwt = new TweetViewModel();
            if (ModelState.IsValid)
            {               
                objTweet.user_id = Session["UserID"].ToString();
                objTweet.created = DateTime.Now;
                objTweet.message = objTwt.objTweet.message;
                db.tweets.Add(objTweet);
                db.SaveChanges();


                objFollow.user_id = Session["UserID"].ToString();
                objFollow.following_id = objTwt.objFollow.following_id;                
                db.followings.Add(objFollow);
                db.SaveChanges();

                oTwt.objTweetList = GetTweetList();
                oTwt.objTweet = new tweet();
                oTwt.objTweet.message = string.Empty;
                oTwt.tweetCount = oTwt.objTweetList.Count.ToString();
                string result = GetFollowingList();
                oTwt.followingCount = result.Split(';')[0];
                oTwt.followersCount = result.Split(';')[1];
                return View(oTwt);
            }
            return View(oTwt);
        }

        // GET: Product_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            AssessmentEntities db = new AssessmentEntities();
            tweet oTwt = db.tweets.Find(id);
            db.tweets.Remove(oTwt);
            db.SaveChanges();
            TweetViewModel oTwts = new TweetViewModel();
            oTwts.objTweetList = GetTweetList();
            oTwts.objTweet = new tweet();
            oTwts.objTweet.message = string.Empty;
            oTwts.tweetCount = oTwts.objTweetList.Count.ToString();
            string result = GetFollowingList();
            oTwts.followingCount = result.Split(';')[0];
            oTwts.followersCount = result.Split(';')[1];
            return View("UserDashBoard",oTwts);
        }        

    }
}