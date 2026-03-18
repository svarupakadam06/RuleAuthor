using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Interfaces;
using FraudMonitoringSystem.Services.Interfaces;
using FraudMonitoringSystem.Exceptions.Customer;
using FraudMonitoringSystem.Exceptions;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _repository;

        public RegistrationService(IRegistrationRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Registers a new user with validation and duplicate checks.
        /// Throws:
        /// - RegisterUserAlreadyExistsException if email already exists
        /// - RegisterValidationException if passwords mismatch
        /// - RegisterDatabaseException if persistence fails
        /// </summary>
        /// <param name="registration">Registration model containing user details</param>
        /// <returns>Success message with assigned role</returns>
        public async Task<string> RegisterAsync(Registration registration)
        {
            // Check for duplicate email
            var existingUser = await _repository.GetByEmailAsync(registration.Email);
            if (existingUser != null)
                throw new RegisterUserAlreadyExistsException("Email already exists");

            // Validate password match
            if (registration.Password != registration.ConfirmPassword)
                throw new RegisterValidationException("Passwords do not match");

            // Save to database
            var result = await _repository.RegisterAsync(registration);
            if (result == 0)
                throw new RegisterDatabaseException("Registration failed to save in database");

            // this is for admin 
            // 🔥 ADD THIS PART (SystemUser logic)
            if (registration.Role != RegisterRole.Customer)
            {
                await _repository.AddSystemUserAsync(registration);
            }

            return $"Registration successful with role: {registration.Role}";
        }

        /// <summary>
        /// Retrieves a user by role.
        /// Throws RegisterUserNotFoundException if no user exists for the role.
        /// </summary>
        /// <param name="role">UserRole enum value</param>
        /// <returns>Registration object if found</returns>
        public async Task<Registration?> GetUserByRoleAsync(RegisterRole role)
        {
            var user = await _repository.GetByRoleAsync(role);
            if (user == null)
                throw new RegisterUserNotFoundException($"No user found with role {role}");

            return user;
        }
        //public async Task<List<Registration>> GetSystemUsersAsync()
        //{
        //    var users = await _repository.GetSystemUsersAsync();
        //    if (!users.Any())
        //        throw new RegisterUserNotFoundException("No system users found");
        //    return users;
        //}

    }
}
