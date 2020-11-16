using Medical.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Description;

namespace Medical.Controllers
{
    public class RegisteredDeviceController : ApiController
    {
        private MedicalContext db = new MedicalContext();

        //public IQueryable<RegisteredDevice> getDevice()
        //{
        //    return db.RegisteredDevices;
        //}

        //[ResponseType(typeof(RegisteredDevice))]
        [HttpGet]
        [Route("GetRegisteredDevice")]
        public IHttpActionResult GetRegisteredDevice()
        {
            List<RegisteredDevice> registeredDevice = new List<RegisteredDevice>();

            registeredDevice = db.RegisteredDevices.ToList<RegisteredDevice>();

            if (registeredDevice.Any())
            {
                return Ok(registeredDevice);
            }
            else
            {
                return NotFound();
            }

        }

        //[ResponseType(typeof(RegisteredDevice))]
        [HttpPost]
        [Route("AddRegisteredDevice")]
        public IHttpActionResult AddRegisteredDevice(RegisteredDevice registeredDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisteredDevices.Add(registeredDevice);
            db.SaveChanges();

            return Ok(registeredDevice);
            
        }

        //[ResponseType(typeof(RegisteredDevice))]
        [HttpDelete]
        [Route("DeleteRegisteredDevice")]
        public IHttpActionResult DeleteRegisteredDevice(int id)
        {
            RegisteredDevice deviceToDelete = db.RegisteredDevices.FirstOrDefault(x => x.id == id);

            if(deviceToDelete == null)
            {
                return NotFound();
            }

            db.RegisteredDevices.Remove(deviceToDelete);
            db.SaveChanges();

            return Ok(deviceToDelete);
        }

        //[ResponseType(typeof(RegisteredDevice))]
        [HttpPut]
        [Route("UpdateRegisteredDevice")]
        public IHttpActionResult UpdateRegisteredDevice(RegisteredDevice registeredDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != registeredDevice.id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(registeredDevice).State = EntityState.Modified;

            RegisteredDevice currentDevice = db.RegisteredDevices.FirstOrDefault(x => x.id == registeredDevice.id);

            if (currentDevice == null)
            {
                return NotFound();
            }
            else
            {
                currentDevice.ipAddress = registeredDevice.ipAddress;
                db.SaveChanges();

                return Ok(currentDevice);
            }
        }


    }
}
