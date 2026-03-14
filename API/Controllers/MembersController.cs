using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MembersController : BaseApiController
    {
        private readonly IMemberRepository _memberRepository;
        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>> GetMembers()
        {
            return Ok(await _memberRepository.GetMembersAsync());
        }


        [HttpGet("{id}")] // localhost:5001/api/members/bob-id
        public async Task<ActionResult<Member>> GetMember(string id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);

            if (member == null) return NotFound();

            return member;
        }

        [HttpGet("{id}/photos")]
        public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
        {
            return Ok(await _memberRepository.GetPhotosForMemberAsync(id));
        }
    }
}
