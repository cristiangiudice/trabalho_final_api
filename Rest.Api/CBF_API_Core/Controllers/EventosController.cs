using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CBF_API_Core;
using CBF_API_Core.Model;
using CBF_API_Core.Repository;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;


namespace CBF_API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        private readonly IEventoRepository _rep;

        private readonly ConnectionFactory _factory;

        public EventosController(ApiDbContext context, IEventoRepository rep)
        {
            _context = context;

            _rep = rep;

            _factory = new ConnectionFactory
            {

                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };

        }

        private void RabbitMQPublisher(Evento evento)
        {
            string QueueName = evento.PartidaId.ToString(); //Nome da fila é o id da Partida

            using (var connection = _factory.CreateConnection())
            {

                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: QueueName, //Nome da fila é o id da Partida
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    var stringEvento = JsonConvert.SerializeObject(evento);
                    var bytesEvento = Encoding.UTF8.GetBytes(stringEvento);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: QueueName,
                        basicProperties: null,
                        body: bytesEvento
                        );
                }
            }
        }

        #region PostEvento
        [HttpPost("partidas/{partidaid}/eventos/inicio")]
        public async Task<IActionResult> PostEventoInicio([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Inicio;
                    evento.DetalheEvento = "Inicio da partida";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/gol")]
        public async Task<IActionResult> PostEventoGol([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Gol;
                    evento.DetalheEvento = "GOOOOLL!!!!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/intervalo")]
        public async Task<IActionResult> PostEventoIntervalo([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Intervalo;
                    evento.DetalheEvento = "Intervalooo!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/acrescimo")]
        public async Task<IActionResult> PostEventoAcrescimo([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Acrescimo;
                    evento.DetalheEvento = "Acrescimoss!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/substituicao")]
        public async Task<IActionResult> PostEventoSubstituicao([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Substituicao;
                    evento.DetalheEvento = "Substituição!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/advertencia")]
        public async Task<IActionResult> PostEventoAdvertencia([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Advertencia;
                    evento.DetalheEvento = "Advertência!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("partidas/{partidaid}/eventos/fim")]
        public async Task<IActionResult> PostEventoFim([FromRoute] Guid partidaid)
        {
            try
            {

                var partida = await _context.Partidas.FindAsync(partidaid);

                if (partida == null)
                {
                    return NotFound(partida);
                }
                else
                {
                    Evento evento = new Evento();

                    evento.Id = Guid.NewGuid();
                    evento.PartidaId = partidaid;
                    evento.TipoEvento = (int)TipoEvento.Fim;
                    evento.DetalheEvento = "Fim da Partida!!";
                    evento.DataEvento = DateTime.Now;

                    var count = await _rep.Add(evento);

                    if (evento == null)
                    {
                        return NotFound();
                    }

                    RabbitMQPublisher(evento);

                    return Ok(evento.Id);
                }
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

        // GET: api/Eventos
        [HttpGet]
        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos;
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento([FromRoute] Guid id, [FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<IActionResult> PostEvento([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }

        private bool EventoExists(Guid id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}