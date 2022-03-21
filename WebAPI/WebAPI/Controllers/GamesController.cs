#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO.GameDTO;
using WebAPI.DTO.PlayerDTO;
using WebAPI.Models;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.ChatDTO;
using WebAPI.Models.DTO.KillDTO;
using WebAPI.Models.DTO.MissionDTO;
using WebAPI.Models.DTO.Squad;

namespace WebAPI.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly HvZContext _context;
        private readonly IMapper _mapper;

        public GamesController(HvZContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game")]
        public async Task<ActionResult<IEnumerable<ReadGameDTO>>> GetGames()
        {
            return _mapper.Map<List<ReadGameDTO>>(await _context.Games.ToListAsync());
        }

        /// <summary>
        /// Gets a Game based on Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}")]
        public async Task<ActionResult<ReadGameDTO>> GetGame(int gameid)
        {
            var game = await _context.Games.FindAsync(gameid);

            if (game == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadGameDTO>(game);
        }

        /// <summary>
        /// Gets all Players in a game based on Game Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/player")]
        public async Task<ActionResult<List<ReadPlayerDTO>>> GetPlayersInGame(int gameid)
        {
            var game = _context.Games.Include(g => g.Players).FirstOrDefault(p => p.Id == gameid);
            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<List<ReadPlayerDTO>>(game.Players.ToList());
        }

        /// <summary>
        /// Gets a specific Player in a Game based on Game Id and Player Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/player/{playerid}")]
        public async Task<ActionResult<ReadPlayerDTO>> GetPlayerInGame(int gameid, int playerid)
        {
            var game = _context.Games.Include(g => g.Players).FirstOrDefault(p => p.Id == gameid);
            Player chosen_player = new Player();
            foreach (Player player in game.Players)
            {
                if(player.Id == playerid)
                {
                    chosen_player = player;
                }
            }
            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReadPlayerDTO>(chosen_player);
        }

        /// <summary>
        /// Gets all Kills in a Game based on Game Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/kill")]
        public async Task<ActionResult<List<ReadKillDTO>>> GetKillsInGame(int gameid)
        {
            var game = _context.Games.Include(g => g.Players).ThenInclude(p => p.Kills).FirstOrDefault(p => p.Id == gameid);
            List<Kill> listOfKills = new List<Kill>();
            if (game == null)
            {
                return NotFound();
            }
          
            foreach (Player player in game.Players)
            {
                foreach (Kill kill in player.Kills)
                {
                    listOfKills.Add(kill);
                }
            }
                        return _mapper.Map<List<ReadKillDTO>>(listOfKills.ToList());
        }

        /// <summary>
        /// Gets a specific Kill in a Game based on Game Id and Kill Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/kill/{killid}")]
        public async Task<ActionResult<ReadKillDTO>> GetKillInGame(int gameid, int killid)
        {
            var game = _context.Games.Include(g => g.Kills).FirstOrDefault(p => p.Id == gameid);
            Kill chosen_kill = new Kill();
            foreach (Kill kill in game.Kills)
            {
                if (kill.Id == killid)
                {
                    chosen_kill = kill;
                }
            }

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReadKillDTO>(chosen_kill);
        }

        /// <summary>
        /// Gets all Missions in a Game based on Game Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/mission")]
        public async Task<ActionResult<List<ReadMissionDTO>>> GetMissionsInGame(int gameid)
        {
            var game = _context.Games.Include(g => g.Missions).FirstOrDefault(p => p.Id == gameid);

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<List<ReadMissionDTO>>(game.Missions.ToList());
        }

        /// <summary>
        /// Gets a specific Mission in a Game based on Game Id and Mission Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/mission/{missionid}")]
        public async Task<ActionResult<ReadMissionDTO>> GetMissionInGame(int gameid, int missionid)
        {
            var game = _context.Games.Include(g => g.Missions).FirstOrDefault(p => p.Id == gameid);
            Mission chosen_mission = new Mission();
            foreach (Mission mission in game.Missions)
            {
                if (mission.Id == missionid)
                {
                    chosen_mission = mission;
                }
            }

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReadMissionDTO>(chosen_mission);
        }

        /// <summary>
        /// Gets all Squads in a Game based on Game Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/squad")]
        public async Task<ActionResult<List<ReadSquadDTO>>> GetSquadsInGame(int gameid)
        {
            var game = _context.Games.Include(g => g.Squads).FirstOrDefault(p => p.Id == gameid);

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<List<ReadSquadDTO>>(game.Squads.ToList());
        }

        /// <summary>
        /// Gets a specific Squad in a Game based on Game Id and Squad Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/squad/{squadid}")]
        public async Task<ActionResult<ReadSquadDTO>> GetSquadInGame(int gameid, int squadid)
        {
            var game = _context.Games.Include(g => g.Squads).FirstOrDefault(p => p.Id == gameid);
            Squad chosen_squad = new Squad();
            foreach (Squad squad in game.Squads)
            {
                if (squad.Id == squadid)
                {
                    chosen_squad = squad;
                }
            }

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReadSquadDTO>(chosen_squad);
        }

        /// <summary>
        /// Gets all Chats in a Game based on Game Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/chat")]
        public async Task<ActionResult<List<ReadChatDTO>>> GetChatsInGame(int gameid)
        {
            var game = _context.Games.Include(g => g.GameChats).FirstOrDefault(p => p.Id == gameid);

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<List<ReadChatDTO>>(game.GameChats.ToList());
        }

        /// <summary>
        /// Gets a specific Chat in a Game based on Game Id and Chat Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("game/{gameid}/chat/{chatid}")]
        public async Task<ActionResult<ReadChatDTO>> GetChatInGame(int gameid, int chatid)
        {
            var game = _context.Games.Include(g => g.GameChats).FirstOrDefault(p => p.Id == gameid);
            Chat chosen_chat = new Chat();
            foreach (Chat chat in game.GameChats)
            {
                if (chat.Id == chatid)
                {
                    chosen_chat = chat;
                }
            }

            if (game == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReadChatDTO>(chosen_chat);
        }


        /// <summary>
        /// Creates a new Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game")]
        public async Task<ActionResult<Game>> PostGame(CreateGameDTO dtoGame)
        {

            Game gameDomain = _mapper.Map<Game>(dtoGame);
            _context.Games.Add(gameDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GamesController.GetGame),
                new { gameid = gameDomain.Id },
                _mapper.Map<CreateGameDTO>(gameDomain));
        }

        /// <summary>
        /// Creates a new Player in specific Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game/{gameid}/player")]
        public async Task<ActionResult<Player>> PostPlayer(CreatePlayerDTO dtoPlayer, int gameid)
        {

            Player playerDomain = _mapper.Map<Player>(dtoPlayer);
            playerDomain.GameId = gameid;
            _context.Players.Add(playerDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
               "GetPlayerInGame",
                new { gameid = playerDomain.GameId, playerid = playerDomain.Id },
                _mapper.Map<CreatePlayerDTO>(playerDomain));
        }

        /// <summary>
        /// Creates a new Kill in specific Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game/{gameid}/kill")]
        public async Task<ActionResult<Kill>> PostKill(CreateKillDTO dtoKill, int gameid)
        {
            //FIX posting to to wrong game if player not included in game, not sure if fix is needed coz e will see all player id in a game
            Kill killDomain = _mapper.Map<Kill>(dtoKill);
            killDomain.GameId = gameid;
            _context.Kills.Add(killDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
               "GetKillInGame",
                new { gameid = killDomain.GameId, killid = killDomain.Id },
                _mapper.Map<CreateKillDTO>(killDomain));
        }

        /// <summary>
        /// Creates a new Mission in specific Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game/{gameid}/mission")]
        public async Task<ActionResult<Mission>> PostKill(CreateMissionDTO dtoMission, int gameid)
        {

            Mission missionDomain = _mapper.Map<Mission>(dtoMission);
            missionDomain.GameId = gameid;
            _context.Missions.Add(missionDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
               "GetMissionInGame",
                new { gameid = missionDomain.GameId, missionid = missionDomain.Id },
                _mapper.Map<CreateMissionDTO>(missionDomain));
        }

        /// <summary>
        /// Creates a new Squad in specific Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game/{gameid}/squad")]
        public async Task<ActionResult<Squad>> PostSquad(CreateSquadDTO dtoSquad, int gameid)
        {

            Squad missionDomain = _mapper.Map<Squad>(dtoSquad);
            missionDomain.GameID = gameid;
            _context.Squads.Add(missionDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
               "GetSquadInGame",
                new { gameid = missionDomain.GameID, squadid = missionDomain.Id },
                _mapper.Map<CreateSquadDTO>(missionDomain));
        }

        /// <summary>
        /// Creates a new Chat in specific Game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("game/{gameid}/chat")]
        public async Task<ActionResult<Chat>> PostChat(CreateChatDTO dtoChat, int gameid)
        {

            Chat chatDomain = _mapper.Map<Chat>(dtoChat);
            chatDomain.GameId = gameid;
            _context.Chats.Add(chatDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
               "GetChatInGame",
                new { gameid = chatDomain.GameId, chatid = chatDomain.Id },
                _mapper.Map<CreateChatDTO>(chatDomain));
        }

        /// <summary>
        /// Update a Game based on Id
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}")]
        public async Task<IActionResult> PutGame(int gameid, EditGameDTO dtoGame)
        {
            Game domainGame = _mapper.Map<Game>(dtoGame);
            domainGame.Id = gameid;
            _context.Entry(domainGame).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
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

        /// <summary>
        /// Update a Player in a Game based on gameId and playerId
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}/player/{playerid}")]
        public async Task<IActionResult> PutPlayer(int gameid,int playerid, EditPlayerDTO dtoPlayer)
        {

            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);
            domainPlayer.GameId = gameid;
            domainPlayer.Id = playerid;
            _context.Entry(domainPlayer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
                {
                    return NotFound();
                } else if(!PlayerExists(playerid)) 
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

        /// <summary>
        /// Update a Mission in a Game based on gameId and missionId
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}/mission/{missionid}")]
        public async Task<IActionResult> PutMission(int gameid, int missionid, EditMissionDTO dtoMission)
        {

            Mission domainMission = _mapper.Map<Mission>(dtoMission);
            domainMission.GameId = gameid;
            domainMission.Id = missionid;
            _context.Entry(domainMission).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
                {
                    return NotFound();
                }
                else if (!MissionExists(missionid))
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

        /// <summary>
        /// Update a Kill in a Game based on gameId and killId
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}/kill/{killid}")]
        public async Task<IActionResult> PutKill(int gameid, int killid, EditKillDTO dtoKill)
        {
            Kill domainKill = _mapper.Map<Kill>(dtoKill);
            domainKill.GameId = gameid;
            domainKill.Id = killid;
            _context.Entry(domainKill).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
                {
                    return NotFound();
                }
                else if (!KillExists(killid))
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

        /// <summary>
        /// Update a Chat in a Game based on gameId and chatId
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}/chat/{chatid}")]
        public async Task<IActionResult> PutChat(int gameid, int chatid, EditChatDTO dtoChat)
        {
            Chat domainChat = _mapper.Map<Chat>(dtoChat);
            domainChat.GameId = gameid;
            domainChat.Id = chatid;
            _context.Entry(domainChat).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
                {
                    return NotFound();
                }
                else if (!ChatExists(chatid))
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

        /// <summary>
        /// Update a Squad in a Game based on gameId and squadId
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("game/{gameid}/squad/{squadid}")]
        public async Task<IActionResult> PutSquad(int gameid, int squadid, EditSquadDTO dtoSquad)
        {
            Squad domainSquad = _mapper.Map<Squad>(dtoSquad);
            domainSquad.GameID = gameid;
            domainSquad.Id = squadid;
            _context.Entry(domainSquad).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(gameid))
                {
                    return NotFound();
                }
                else if (!SquadExists(squadid))
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

        /// <summary>
        /// Deletes a game based on the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}")]
        public async Task<IActionResult> DeleteGame(int gameid)
        {
            var game = await _context.Games.FindAsync(gameid);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes a player based on the gameid and playerid
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}/player/{playerid}")]
        public async Task<IActionResult> DeletePlayer(int gameid,int playerid)
        {
            var player = await _context.Players.FindAsync(playerid);
            var game = await _context.Games.FindAsync(gameid);
            if (game == null)
            {
                return NotFound();
            }
            if (player == null)
            {
                return NotFound();
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a mission based on the gameid and missionid
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}/mission/{missionid}")]
        public async Task<IActionResult> DeleteMission(int gameid, int missionid)
        {
            var game = await _context.Games.FindAsync(gameid);
            var mission = await _context.Missions.FindAsync(missionid);
            if (game == null)
            {
                return NotFound();
            }
            if (mission == null)
            {
                return NotFound();
            }
            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a chat based on the gameid and missionid
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}/chat/{chatid}")]
        public async Task<IActionResult> DeleteGlobalChat(int gameid, int chatid)
        {
            var game = await _context.Games.FindAsync(gameid);
            var chat = await _context.Chats.FindAsync(chatid);
            if (game == null)
            {
                return NotFound();
            }
            if (chat == null)
            {
                return NotFound();
            }
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a kill based on the gameid and killid
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}/kill/{killid}")]
        public async Task<IActionResult> DeleteKill(int gameid, int killid)
        {
            var game = await _context.Games.FindAsync(gameid);
            var kill = await _context.Kills.FindAsync(killid);
            if (game == null)
            {
                return NotFound();
            }
            if (kill == null)
            {
                return NotFound();
            }
            _context.Kills.Remove(kill);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a squad based on the gameid and squadid
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("game/{gameid}/squad/{squadid}")]
        public async Task<IActionResult> DeleteSquad(int gameid, int squadid)
        {
            var game = await _context.Games.FindAsync(gameid);
            var squad = await _context.Squads.FindAsync(squadid);
            if (game == null)
            {
                return NotFound();
            }
            if (squad == null)
            {
                return NotFound();
            }
            _context.Squads.Remove(squad);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GameExists(int gameid)
        {
            return _context.Games.Any(e => e.Id == gameid);
        }

        private bool PlayerExists(int playerid)
        {
            return _context.Players.Any(e => e.Id == playerid);
        }

        private bool MissionExists(int missionid)
        {
            return _context.Missions.Any(e => e.Id == missionid);
        }

        private bool KillExists(int killid)
        {
            return _context.Kills.Any(e => e.Id == killid);
        }

        private bool ChatExists(int chatid)
        {
            return _context.Chats.Any(e => e.Id == chatid);
        }

        private bool SquadExists(int squadid)
        {
            return _context.Chats.Any(e => e.Id == squadid);
        }


    }
}
