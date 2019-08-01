using FossTechCrm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FossTechCrm.Controllers
{
    public class MailRecipientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MailRecipients
        public async Task<ActionResult> Index()
        {
            var model = new MailRecipientsViewModel();

            // Get a list of all the recipients:
            var recipients = await db.MailRecipients.ToListAsync();
            foreach (var item in recipients)
            {
                // Put the relevant data into the ViewModel:
                var newRecipient = new SelectRecipientEditorViewModel()
                {
                    MailRecipientId = item.MailRecipientId,
                    FullName = item.FullName,
                    Company = item.Company,
                    Email = item.Email,
                    MesgTemp = item.MesgTemp,
                    LastMailedDate = item.getLastEmailDate().HasValue ? item.getLastEmailDate().Value.ToShortDateString() : "",
                    Selected = true
                };

                // Add to the list contained by the "wrapper" ViewModel:
                model.MailRecipients.Add(newRecipient);
            }
            // Pass to the view and return:
            return View(model);
        }

        public ActionResult SendMail(MailRecipientsViewModel recipients)

        {

            // Retrieve the ids of the recipients selected:

            var selectedIds = recipients.getSelectedRecipientIds();



            // Grab the recipient records:

            var selectedMailRecipients = this.LoadRecipientsFromIds(selectedIds);



            // Build the message container for each:

            var messageContainers = this.createRecipientMailMessages(selectedMailRecipients);



            // Send the mail:

            var sender = new MailSender();

            var sent = sender.SendMail(messageContainers);



            // Save a record of each mail sent:

            this.SaveSentMail(sent);



            // Reload the index form:

            return RedirectToAction("Index");

        }
        IEnumerable<MailRecipient> LoadRecipientsFromIds(IEnumerable<int> selectedIds)
        {
            var selectedMailRecipients = from r in db.MailRecipients
                                         where selectedIds.Contains(r.MailRecipientId)
                                         select r;
            return selectedMailRecipients;
        }


        IEnumerable<Message> createRecipientMailMessages(
            IEnumerable<MailRecipient> selectedMailRecipients)
        {
            var messageContainers = new List<Message>();
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            foreach (var recipient in selectedMailRecipients)
            {
                var msg = new Message()
                {
                    Recipient = recipient,
                    User = currentUser,
                    Subject = string.Format("Welcome, {0}", recipient.FullName),
                    MessageBody = this.getMessageText(recipient, currentUser)
                };
                messageContainers.Add(msg);
            }
            return messageContainers;
        }


        void SaveSentMail(IEnumerable<SentMail> sentMessages)
        {
            foreach (var sent in sentMessages)
            {
                db.SentMails.Add(sent);
                db.SaveChanges();
            }
        }


        string getMessageText(MailRecipient recipient, ApplicationUser user)
        {
            return ""
            + string.Format("Dear {0}, ", recipient.FullName) + Environment.NewLine
            + "Thank you for your interest in our latest product. "
              + Environment.NewLine
              + Environment.NewLine
     
            + string.Format("{0}", recipient.MesgTemp)
              + Environment.NewLine
              + Environment.NewLine
           
            + "Please feel free to contact me for more information!"
            + Environment.NewLine
            + Environment.NewLine
            + "Sincerely, "
            + Environment.NewLine
            + string.Format("{0}", user.UserName);
        }

        // GET: MailRecipients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = db.MailRecipients.Find(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // GET: MailRecipients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailRecipients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstName,Email,Company,MesgTemp")] MailRecipient mailRecipient)
        {
            if (ModelState.IsValid)
            {
                db.MailRecipients.Add(mailRecipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailRecipient);
        }

        // GET: MailRecipients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = db.MailRecipients.Find(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // POST: MailRecipients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MailRecipientId,LastName,FirstName,Email,Company,MesgTemp")] MailRecipient mailRecipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailRecipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailRecipient);
        }

        // GET: MailRecipients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = db.MailRecipients.Find(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // POST: MailRecipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailRecipient mailRecipient = db.MailRecipients.Find(id);
            db.MailRecipients.Remove(mailRecipient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}