using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scorerecord.DTOS;
using Scorerecord.Services;

namespace Scorerecord.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventObjectController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IEventService _eventService;
        private readonly IObjectTypeService _objectTypeService;
        private readonly IEventObjectService _eventObjectService;
        private readonly IMemberService _memberService;

        public EventObjectController(IMemberService memberService, ICompanyService companyService, IEventService eventService, IObjectTypeService objectTypeService, IEventObjectService eventObjectService)
        {
            _memberService = memberService;
            _companyService = companyService;
            _eventService = eventService;
            _objectTypeService = objectTypeService;
            _eventObjectService = eventObjectService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(string parentEventObjectId)
        {
            EventObject eventObject = new EventObject();
            ViewBag.MemberId = new SelectList(await _memberService.GetAllByRole(Domain.Common.Roles.Facilitator), "Id", "Name");
            ViewBag.ObjectTypeId = new SelectList(await _objectTypeService.GetAll(), "Id", "Name");
            ViewBag.ParentEventObjectId = parentEventObjectId;
            if (!string.IsNullOrEmpty(parentEventObjectId))
                eventObject = await _eventObjectService.GetAsync(Guid.Parse(parentEventObjectId));
            return View(eventObject);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EventObject eventObject)
        {
            try
            {
                if (eventObject.ObjectTypeId == Guid.Parse("D9D70AFD-99E1-459D-9D96-384F9656B3F6"))
                {
                    eventObject.IsActivityTime = eventObject.IsActivityTime == true ? eventObject.IsActivityTime : false;
                    eventObject.IsAverageSpeed = eventObject.IsActivityTime == true ? false : true;
                }
               await _eventObjectService.AddEventObject(eventObject);
                return View(eventObject);
            }
            catch
            {
                return View(eventObject);
            }
        }
    }
}
