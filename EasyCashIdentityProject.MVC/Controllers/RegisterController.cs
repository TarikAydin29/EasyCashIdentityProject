using AutoMapper;
using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int rndCode= rnd.Next(100000, 1000000);
                //AppUser appUser = new AppUser()
                //{
                //    UserName=appUserRegisterDto.UserName,
                //    Name=appUserRegisterDto.Name,
                //    Surname=appUserRegisterDto.Surname,
                //    Email=appUserRegisterDto.Email
                //};
                var mappedUser = mapper.Map<AppUser>(appUserRegisterDto);
                mappedUser.ConfirmCode = rndCode;
                mappedUser.City = "a";
                mappedUser.District = "b";
                mappedUser.ImageUrl = "c";


                var result = await userManager.CreateAsync(mappedUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin","demoprojemail@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", mappedUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz : " + rndCode;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("demoprojemail@gmail.com", "vhlcgplmlqoqpnjf");
                    client.Send(mimeMessage);
                    client.Disconnect(true);


                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
