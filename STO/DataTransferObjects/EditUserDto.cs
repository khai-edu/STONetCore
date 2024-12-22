using Microsoft.AspNetCore.Mvc.Rendering;
using STO.Models;
namespace STO.DataTransferObjects;

public record EditUserDto
(
    User user,
    int PersonId,
    IEnumerable<SelectListItem> PersonList,
    IEnumerable<SelectListItem> RoleList
);
