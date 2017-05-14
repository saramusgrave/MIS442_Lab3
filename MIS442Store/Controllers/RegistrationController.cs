using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using MIS442Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class RegistrationController : Controller
    {
        private IStateRepository _staterepo;
        private IRegistrationRepository _registrationreop;
        public RegistrationController()
        {
            _staterepo = new StateRepository();
            _registrationreop = new RegistrationRepository();
        }
        // GET: Registration
        [HttpGet]

        public ActionResult Index()
        {
            ViewBag.Header = "Registrations";
            return View(_registrationreop.GetUserRegistrations("sara"));
        }
        [HttpGet]
        public ActionResult AddRegistration()
        {
            RegistrationModel model = new RegistrationModel();
            model.States = _staterepo.GetState();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddRegistration(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                registration.States = _staterepo.GetState();
                return View(registration);
            }
            Registration regdata = new Registration();
            regdata.RegistrationAddress = registration.RegistrationAddress;
            regdata.RegistrationCity = registration.RegistrationCity;
            regdata.RegistrationDate = registration.RegistrationDate;
            regdata.RegistrationID = registration.RegistrationID;
            regdata.RegistrationPhone = registration.RegistrationPhone;
            regdata.RegistrationProductID = registration.RegistrationProductID;
            regdata.RegistrationSerialNumber = registration.RegistrationSerialNumber;
            regdata.RegistrationState = registration.RegistrationState;
            regdata.RegistrationUserName = registration.RegistrationUserName;
            regdata.RegistrationVerified = registration.RegistrationVerified;
            regdata.RegistrationZip = registration.RegistrationZip;
            
            _registrationreop.SaveRegistration(regdata);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminIndex()
        {
            ViewBag.Title = "Registraiton";
            ViewBag.Header = "Registration";
            return View(_registrationreop.GetRegistrations());
        }
    }
}