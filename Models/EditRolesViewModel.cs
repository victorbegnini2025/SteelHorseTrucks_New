namespace SteelHorseTrucks.Models
{
    public class EditRolesViewModel
    {
        public string UserId { get; set; }
        public string? Email { get; set; }
        public List<string> AvailableRoles { get; set; } = new();
        public List<string> AssignedRoles { get; set; } = new();
        public List<string> SelectedRoles { get; set; } = new();
    }
}
