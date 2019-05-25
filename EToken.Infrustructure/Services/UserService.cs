using EToken.Core.Model;
using EToken.Core.Repositories;
using EToken.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EToken.Core.Services.Communication;
using EToken.Core.Securities;


namespace EToken.Infrustructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepositories;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepositories userRepositories, IUnitOfWork unitOfWork)
        {
            this._userRepositories = userRepositories;
            this._unitOfWork = unitOfWork;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepositories.FindByUserName(username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
        public async Task<UserResponse> CreateAsync(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return new UserResponse("Password is required");
            var IsPresent = await _userRepositories.FindByUserName(user.Username);
            if (IsPresent!=null)
                return new UserResponse("Username \"" + user.Username + "\" is already taken");
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);    
            try
            {
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _userRepositories.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured when saving the category: {ex.Message}");
            }

        }
        
        public async Task<UserResponse> DeleteAsync(int id)
        {
            var user = await _userRepositories.FindByIdAsync(id);
            if (user == null)
                return new UserResponse("User Not Found");
            try
            {
                _userRepositories.Remove(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured while delete the category:{ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepositories.ListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepositories.FindByIdAsync(id);
        }

        public async Task<UserResponse> UpdateAsync(User userParam, string password = null)
        {
            var user = await _userRepositories.FindByIdAsync(userParam.Id);
            if (user == null)
                return new UserResponse("User Not Found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_userRepositories.FindByUserName(userParam.Username)!= null)
                    return new UserResponse("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            try
            {
                _userRepositories.Update(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"an error occured when updating the category: {ex.Message}");
            }
        }
    }


}

