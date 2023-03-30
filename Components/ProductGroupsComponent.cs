using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEshop.Data.Repositories;
namespace MyEshop.Components;

public class ProductGroupsComponent : ViewComponent
{
    #nullable disable
    private IGroupRepository _groupRepository;
    public ProductGroupsComponent(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = _groupRepository.GetGroupForShow();
        return View("/Views/Components/ProductGroupsComponent.cshtml", 
         categories);
    }
}
