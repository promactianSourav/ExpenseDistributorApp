using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }



        [HttpGet("check")]
        //[Authorize]
        public ActionResult<MessageAC> Check()
        {
            MessageAC m = new MessageAC();
            m.Message = "Unauthorized user! Either password or username is wrong.";
            
            var result = false;
            if (result)
            {
                return Ok();
            }
            else
            {
                return Ok(m);
            }

        }
        [HttpGet("getusers")]
        //[Authorize]
        public ActionResult<List<UserAC>> getlist()
        {
            
            var list = userRepository.GetListOfUsers().ToList();
            var listuserDto = mapper.Map<List<User>, List<UserAC>>(list);
            //if (listuserDto.Count == 0)
            //{
            //    return Ok(new { Message = "List is empty." });
            //}
            //return Ok(new { Message="You got the list.",Userlist= listuserDto });
            return Ok(listuserDto );

        }

       


        [HttpPost("login")]
        //[Authorize]
        public ActionResult<MessageAC> PostLogin([FromBody] LoginAC loginAC)
        {
            var result = userRepository.Login(loginAC.Email,loginAC.Password);
            var friendId = userRepository.GetUserFriendId(result);
           
            MessageAC m = new MessageAC();
            
            if (result != -1)
            {
                m.Message = "Logged in Successfully.";
                m.UserId = result;
                m.FriendUserId = friendId;
                return Ok(m);
                //return Ok(new { Message = "Logged in Successfully." });
            }
            else
            {
                m.Message = "Unauthorized user! Either password or username is wrong.";
                m.UserId = -10;
                m.FriendUserId = -10;
                return Ok(m);
                //return Ok(new { Message= "Unauthorized user! Either password or username is wrong." }) ;
            }

        }

        [HttpPost("register")]
        //[Authorize]
        public ActionResult<UserReturnAC> PostRegister([FromBody] UserAC userAC)
        {
            
            var user = mapper.Map<UserAC, User>(userAC);
            var user2 = userRepository.CreateNewUser(user);
            var userDto = mapper.Map<User, UserReturnAC>(user2);
            var friend = mapper.Map<User, Friend>(user2);
            var friend2 = userRepository.CreateFriend(user2.UserId, friend);
            var friendDto = mapper.Map<Friend, FriendAC>(friend2);
            //UserViewModel _userViewModel = new UserViewModel()
            //{
            //    User = userRepository.CreateNewUser(userViewModel.User)
            //};
            return Ok(userDto);
            //return Ok(new { User=userDto,Friend=friendDto});
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public ActionResult<UserReturnAC> Get([FromRoute] long userId)
        {
            
            var user = userRepository.GetUser(userId);
            var userDto = mapper.Map<User, UserReturnAC>(user);
            //UserViewModel userViewModel = new UserViewModel()
            //{
            //    User = userRepository.GetUser(userId)
            //};

            return Ok(userDto);
        }

        [HttpPut("{userId}")]
        //[Authorize]
        public ActionResult<UserReturnAC> Update([FromRoute] long userId, [FromBody] UserReturnAC userReturnAC)
        {
            var user = mapper.Map<UserReturnAC, User>(userReturnAC);
            var user2 = userRepository.UpdateUser(userId, user);
            var userReturnDto = mapper.Map<User, UserReturnAC>(user2);
            //UserViewModel _userViewModel = new UserViewModel()
            //{
            //    User = userRepository.UpdateUser(userId,userViewModel.User)
            //};

            return Ok(userReturnDto);
        }

        //[HttpDelete("{userId}")]
        ////[Authorize]
        //public IActionResult Delete([FromRoute] long userId)
        //{
        //    userRepository.DeleteUser(userId);
        //    return Ok();
        //}

    }
}
