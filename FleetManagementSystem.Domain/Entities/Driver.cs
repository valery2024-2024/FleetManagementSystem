namespace FleetManagementSystem.Domain.Entities;

public class Driver
{
    private string _fullName = string.Empty;
    private int _experienceYears;

    public int Id { get; private set; }

    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я не може бути пустим");

            _fullName = value;
        }
    }

    public string LicenseCategory { get; private set; }

    public int ExperienceYears
    {
        get => _experienceYears;
        set
        {
            if (value < 0)
                throw new ArgumentException("Досвід не може бути менше 0");

            _experienceYears = value;
        }
    }

    public Driver(int id, string fullName, string licenseCategory, int experienceYears)
    {
        Id = id;
        FullName = fullName;
        LicenseCategory = licenseCategory;
        ExperienceYears = experienceYears;
    }
}