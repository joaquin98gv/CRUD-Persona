using CRUD_Persona.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRUD_Persona.Controllers
{
    public class PersonaController : ControllerManager
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetPersonas()
        {
            try
            {
                return Ok(db.Persona.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            try
            {
                return Ok(db.Persona.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(Persona obj)
        {
            try
            {
                db.Persona.Add(obj);
                db.SaveChanges();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Edit(Persona obj)
        {
            try
            {
                Persona persona = db.Persona.FirstOrDefault(x => x.Id == obj.Id);

                persona.Nombre = obj.Nombre;
                persona.PrimerApellido = obj.PrimerApellido;
                persona.SegundoApellido = obj.SegundoApellido;
                persona.FechaNacimiento = obj.FechaNacimiento;
                persona.Sexo = obj.Sexo;

                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Persona persona = db.Persona.FirstOrDefault(x => x.Id == id);

                db.Persona.Remove(persona);
                db.SaveChanges();
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
