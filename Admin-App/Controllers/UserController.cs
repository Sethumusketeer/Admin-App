using LogRegister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LogRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DynamicDbContext _context;

        public UserController(DynamicDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData user)
        {
            var users = await _context.UserData.FirstOrDefaultAsync(x => x.EmpId == user.EmpId && x.Password == user.Password);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserData>> Register(UserRegistrationDetails registerModel)
        {
            var existingUser = await _context.UserData.FirstOrDefaultAsync(user => user.Email == registerModel.PersonalEmail);
            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            var userdeatils = new PersonalDetails
            {
                Name = registerModel.Name,
                PersonalEmail = registerModel.PersonalEmail,
                DateOfBirth = registerModel.DateOfBirth,
                Gender = registerModel.Gender,
                Age = registerModel.Age,
                Address = registerModel.Address
            };

            _context.PersonalDetails.Add(userdeatils);
            _context.SaveChanges();

            var personalData = await _context.PersonalDetails.FirstOrDefaultAsync(x => x.PersonalEmail == registerModel.PersonalEmail).ConfigureAwait(false);

            var newUser = new UserData
            {
                EmpId = personalData.EmpId,
                Email = registerModel.PersonalEmail,
                Password = registerModel.Password
            };



            _context.UserData.Add(newUser);

            _context.SaveChanges();

            return CreatedAtAction(nameof(Login), newUser);
        }

        [HttpGet("userdetails/{empid}")]
        public async Task<IActionResult> UserDetails(int empid)
        {
            var personalDetails = await _context.PersonalDetails.FirstOrDefaultAsync(x => x.EmpId == empid).ConfigureAwait(false);
            if (personalDetails == null)
            {
                return NotFound();
            }
            var professionalDetails = await _context.ProfessionalDetails.FirstOrDefaultAsync(x => x.EmpId == empid).ConfigureAwait(false);
            var otherDetails = await _context.OtherDetails.FirstOrDefaultAsync(x => x.EmpId == empid).ConfigureAwait(false);
            var profilePicture = await _context.ProfilePicture.FirstOrDefaultAsync(x => x.EmpId == empid);

            var employeeDetails = new EmployeeDetails
            {
                EmpId = empid,
                Name = personalDetails.Name,
                PersonalEmail = personalDetails.PersonalEmail,
                DateOfBirth = personalDetails.DateOfBirth,
                Gender = personalDetails.Gender,
                Age = personalDetails.Age,
                Address = personalDetails.Address
            };

            if (professionalDetails != null)
            {
                employeeDetails.Email = professionalDetails.Email;
                employeeDetails.Designation = professionalDetails.Designation;
                employeeDetails.DateJoined = professionalDetails.DateJoined;
                employeeDetails.JobTitle = professionalDetails.JobTitle;
                employeeDetails.Department = professionalDetails.Department;
                employeeDetails.Manager = professionalDetails.Manager;
            }

            if (otherDetails != null)
            {
                employeeDetails.Shift = otherDetails.Shift;
                employeeDetails.Location = otherDetails.Location;
                employeeDetails.Visa = otherDetails.Visa;
                employeeDetails.Languages = otherDetails.Languages;
            }

            if (profilePicture != null)
            {
                var imageDataUrl = new FileContentResult(profilePicture.ImageData, "image/jpeg");

                employeeDetails.ImageData = imageDataUrl;
            }

            return Ok(employeeDetails);
        }

        [HttpPost("updatepersonaldetails/{empId}")]
        public async Task<IActionResult> UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            var existingUser = await _context.UserData.FirstOrDefaultAsync(user => user.EmpId == personalDetails.EmpId);
            if (existingUser == null)
            {
                return BadRequest("User Not Found");
            }

            var existingDetails = await _context.PersonalDetails.FirstOrDefaultAsync(details => details.EmpId == personalDetails.EmpId);
            if (existingDetails == null)
            {
                return BadRequest("Details Not Found");
            }

            existingDetails.Name = personalDetails.Name;
            existingDetails.PersonalEmail = personalDetails.PersonalEmail;
            existingDetails.DateOfBirth = personalDetails.DateOfBirth;
            existingDetails.Gender = personalDetails.Gender;
            existingDetails.Age = personalDetails.Age;
            existingDetails.Address = personalDetails.Address;

            _context.PersonalDetails.Update(existingDetails);
            _context.SaveChanges();

            return Ok(existingDetails);
        }

        [HttpPost("updateProfessionalDetails/{empId}")]
        public async Task<IActionResult> UpdateProfessionalDetails(ProfessionalDetails professionalDetails)
        {
            var existingUser = await _context.UserData.FirstOrDefaultAsync(user => user.EmpId == professionalDetails.EmpId);
            if (existingUser == null)
            {
                return BadRequest("User Not Found");
            }

            var existingDetails = await _context.ProfessionalDetails.FirstOrDefaultAsync(details => details.EmpId == professionalDetails.EmpId);
            if (existingDetails != null)
            {
                existingDetails.Email = professionalDetails.Email;
                existingDetails.Designation = professionalDetails.Designation;
                existingDetails.DateJoined = DateTime.Parse(professionalDetails.DateJoined.ToString());
                existingDetails.JobTitle = professionalDetails.JobTitle;
                existingDetails.Department = professionalDetails.Department;
                existingDetails.Manager = professionalDetails.Manager;

                _context.ProfessionalDetails.Update(existingDetails);
                _context.SaveChanges();

                return Ok(existingDetails);
            }

            var userdetails = new ProfessionalDetails
            {
                EmpId = existingUser.EmpId,
                Email = professionalDetails.Email,
                Designation = professionalDetails.Designation,
                DateJoined = DateTime.Parse(professionalDetails.DateJoined.ToString()),
                JobTitle = professionalDetails.JobTitle,
                Department = professionalDetails.Department,
                Manager = professionalDetails.Manager
            };
            _context.ProfessionalDetails.Add(userdetails);
            _context.SaveChanges();

            return Ok(userdetails);
        }

        [HttpPost("updateotherdetails/{empId}")]
        public async Task<IActionResult> UpdateOtherDetails(OtherDetails otherDetails)
        {
            var existingUser = await _context.UserData.FirstOrDefaultAsync(user => user.EmpId == otherDetails.EmpId);
            if (existingUser == null)
            {
                return BadRequest("User Not Found");
            }

            var existingDetails = await _context.OtherDetails.FirstOrDefaultAsync(details => details.EmpId == otherDetails.EmpId);
            if (existingDetails != null)
            {
                existingDetails.Shift = otherDetails.Shift;
                existingDetails.Location = otherDetails.Location;
                existingDetails.Visa = otherDetails.Visa;
                existingDetails.Languages = otherDetails.Languages;

                _context.OtherDetails.Update(existingDetails);
                _context.SaveChanges();

                return Ok(existingDetails);
            }

            var userdetails = new OtherDetails
            {
                EmpId = existingUser.EmpId,
                Shift = otherDetails.Shift,
                Location = otherDetails.Location,
                Visa = otherDetails.Visa,
                Languages = otherDetails.Languages
            };
            _context.OtherDetails.Add(userdetails);
            _context.SaveChanges();


            return Ok(userdetails);
        }

        [HttpGet("getProfileImage/{empId}")]
        public async Task<IActionResult> GetProfileImage(int empId)
        {
            var image = await _context.ProfilePicture.Where(x => x.EmpId == empId).Select(x => x.ImageData).FirstOrDefaultAsync();

            var stream = new MemoryStream(image);
            return new FileStreamResult(stream, "image/jpeg");
        }

        [HttpPost("updateProfilePic/{empId}")]
        public async Task<IActionResult> UpdateProfilePic(int empId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            try
            {
                var user = await _context.UserData.FirstOrDefaultAsync(user => user.EmpId == empId);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var existingImage = await _context.ProfilePicture.FindAsync(empId);
                if (existingImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await image.CopyToAsync(memoryStream);
                        existingImage.ImageData = memoryStream.ToArray();
                        _context.ProfilePicture.Update(existingImage);
                        await _context.SaveChangesAsync();
                        return Ok("Profile picture updated successfully");
                    }
                }

                var newPic = new ProfilePicture();
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    newPic.ImageData = memoryStream.ToArray();
                    newPic.EmpId = user.EmpId;
                    newPic.ImageName = "DP Picture";
                }

                _context.ProfilePicture.Add(newPic);
                await _context.SaveChangesAsync();

                return Ok("Profile picture updated successfully");
            }
            catch
            {
                return StatusCode(500, "An error occurred while trying to update the profile picture");
            }
        }
    }
}
