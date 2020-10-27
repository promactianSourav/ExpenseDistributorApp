using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Groups;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupRepository groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public IActionResult GetList(long userId)
        {
            var list = groupRepository.GetAllGroups(userId);
            return Ok(list);
        }

        [HttpPost("{userId}")]
        //[Authorize]
        public IActionResult Create(long userId,GroupViewModel groupViewModel)
        {
            GroupViewModel _groupViewModel = new GroupViewModel()
            {
                Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            };

            return Ok(_groupViewModel);
        }

        [HttpPut("{userId}/{groupId}")]
        //[Authorize]
        public IActionResult Update(long userId,long groupId, GroupViewModel groupViewModel)
        {
            GroupViewModel _groupViewModel = new GroupViewModel()
            {
                Group = groupRepository.UpdateGroup(userId, groupId,groupViewModel.Group)
            };

            return Ok(_groupViewModel);
        }

        [HttpDelete("{userId}/{groupId}")]
        //[Authorize]
        public IActionResult Delete(long userId,long groupId)
        {
            groupRepository.DeleteGroup(userId, groupId);
            return Ok();
        }

    }
}
