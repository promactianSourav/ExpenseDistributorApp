using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Groups;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;

        public GroupController(IGroupRepository groupRepository,IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public IActionResult GetList([FromRoute] long userId)
        {
            var list = groupRepository.GetAllGroups(userId).ToList();
            var listGroupDto = mapper.Map<List<Group>, List<GroupAC>>(list);
            return Ok(listGroupDto);
        }

        [HttpPost("{userId}")]
        //[Authorize]
        public IActionResult Create([FromRoute] long userId, [FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.CreateGroup(userId, group);
            var groupDto = mapper.Map<Group, GroupAC>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupDto);
        }

        [HttpPut("{userId}/{groupId}")]
        //[Authorize]
        public IActionResult Update([FromRoute] long userId, [FromRoute] long groupId,[FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.UpdateGroup(userId, groupId, group);
            var groupDto = mapper.Map<Group, GroupAC>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.UpdateGroup(userId, groupId,groupViewModel.Group)
            //};

            return Ok(groupDto);
        }

        //[HttpDelete("{userId}/{groupId}")]
        ////[Authorize]
        //public IActionResult Delete([FromRoute] long userId, [FromRoute] long groupId)
        //{
        //    groupRepository.DeleteGroup(userId, groupId);
        //    return Ok();
        //}

    }
}
