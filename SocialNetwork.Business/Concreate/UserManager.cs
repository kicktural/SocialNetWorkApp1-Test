using AutoMapper;
using MassTransit;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Security.HashHelper;
using SocialNetwork.Core.Utilities.Business;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concreate.ErrorResult;
using SocialNetwork.Core.Utilities.Result.Concreate.SuccessResult;
using SocialNotework.DataAccess.Abstract;
using SocialNotework.Entities.Concreate;
using SocialNotework.Entities.DTOs.UserDTOs;
using SocialNotework.Entities.SharedModel;

namespace SocialNetwork.Business.Concreate
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserManager(IUserDAL userDAL, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public IResult AddFriend(int userId, int firendId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserProfileDTO> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult Login(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public IResult Register(UserRegisterDTO userRegisterDTO)
        {
            var result = BusinessRules.Check(CheckUserAge(userRegisterDTO.Birthday), CheckUserEmail(userRegisterDTO.Email));

            if (!result.Success)
                return new ErrorResult("Email Exsis!");

            var mapToUser = _mapper.Map<User>(userRegisterDTO); 
            mapToUser.Avatar = "//";
            mapToUser.CoverPhoto = "//";

            mapToUser.EmailToken = Guid.NewGuid().ToString();
            byte[] passwordHash, passwordSalt;
            Hasing.HashPassword(userRegisterDTO.Password, out passwordHash, out passwordSalt);

            mapToUser.PasswordHash = passwordHash;
            mapToUser.PasswordSalt = passwordSalt;
            mapToUser.EmailExpiresData = DateTime.Now.AddMinutes(1);

            SendEmailCommand sendEmailCommand = new()
            {
                Email = mapToUser.Email,
                Name = mapToUser.Name,
                Surname = mapToUser.Surname,
                Token = mapToUser.EmailToken
            };
            _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);

            _userDAL.Add(mapToUser);
            return new SuccessResult();
        }

        private IResult CheckUserAge(DateTime birthday)
        {
            var check = DateTime.Now.Year - birthday.Year;
            if (check < 18)
                return new ErrorResult();

            return new SuccessResult();
        }

        private IResult CheckUserEmail(string email)
        {
            var check = _userDAL.Get(x => x.Email == email);
            //if(check != null) null beraber deyilse
            if (check is not null)
                return new ErrorResult();

            return new SuccessResult();
        }
        public IResult SendEmail()
        {
            throw new NotImplementedException();
        }

        public IResult VerifyEmail(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
