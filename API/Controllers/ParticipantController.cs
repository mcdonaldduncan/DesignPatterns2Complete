using Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        DbService _dbService = new DbService();

        [HttpGet]
        public ActionResult<List<Participant>> GetAllParticipants()
        {
            var participants = _dbService.GetAllParticipants();
            return Ok(participants);
        }

        [HttpGet("{name}")]
        public ActionResult<List<Participant>> GetParticipantsByName(string name)
        {
            var participants = _dbService.GetParticipantsByName(name);
            return Ok(participants);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParticipant(int id)
        {
            _dbService.DeleteParticipant(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateParticipant(int id, [FromBody] Participant participant)
        {
            if (participant == null || participant.ID != id)
            {
                return BadRequest();
            }

            _dbService.UpdateParticipant(id, participant.Name ?? string.Empty, participant.GemStone ?? string.Empty);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddParticipant([FromBody] Participant participant)
        {
            if (participant == null || string.IsNullOrEmpty(participant.Name) || string.IsNullOrEmpty(participant.GemStone))
            {
                return BadRequest();
            }

            _dbService.AddParticipant(participant.Name, participant.GemStone);
            return NoContent();
        }
    }
}
