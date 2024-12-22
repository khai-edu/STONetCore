using Microsoft.AspNetCore.Mvc.Rendering;
using STO.Models;
namespace STO.DataTransferObjects;

public record EditModelDto
(
    Model model,
    int BrandId,
    IEnumerable<SelectListItem> BrandList
    
);
