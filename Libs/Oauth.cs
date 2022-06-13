using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using SurveyConsole.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SurveyConsole.Libs
{
    public class Oauth
    {
        public string Authorization { get; set; }

        private static string publicKey = System.IO.File.ReadAllText(AppContext.BaseDirectory + "/Libs/PublicKey/id_rsa.pub");


        public static bool IsValid(HttpContext http)
        {
            try
            {
                String bearer = http.Request.Headers["Authorization"].ToString();
                var arrString = bearer.Split(' ');
                String token = arrString[1].ToString();

                var rs256Token = publicKey;
                Validate(token, rs256Token);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        private static void Validate(string token, string key)
        {
            var keyBytes = Convert.FromBase64String(key); // your key here

            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            RSAParameters rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParameters);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    RequireSignedTokens = true,
                    ValidateAudience = true,
                    ValidAudience = "7",
                    ValidateIssuer = false,
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };
                var handler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                var result = handler.ValidateToken(token, validationParameters, out validatedToken);
            }
        }

        public static List<String> Generate(HttpContext http, Dictionary<String, Object> claims, AppsSettings setting)
        {
            var keyBytes = Convert.FromBase64String(publicKey); // your key here
            List<String> result = new List<string>();

            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            RSAParameters rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParameters);
                var securityTokenDescriptor = new SecurityTokenDescriptor();
                securityTokenDescriptor.Claims = claims;
                securityTokenDescriptor.Expires = DateTime.Now.AddDays(7);
                securityTokenDescriptor.Issuer = http.Connection.LocalIpAddress.ToString();
                securityTokenDescriptor.IssuedAt = DateTime.Now;
                securityTokenDescriptor.Audience = "7";

                var refreshTokenDescriptor = new SecurityTokenDescriptor();
                securityTokenDescriptor.Claims = claims;
                securityTokenDescriptor.Expires = DateTime.Now.AddDays(14);
                securityTokenDescriptor.Issuer = http.Connection.LocalIpAddress.ToString();
                securityTokenDescriptor.IssuedAt = DateTime.Now;
                securityTokenDescriptor.Audience = "7";

                var handler = new JwtSecurityTokenHandler();

                var token = handler.CreateJwtSecurityToken(securityTokenDescriptor);
                var refreshToken = handler.CreateJwtSecurityToken(refreshTokenDescriptor);

                result.Add(new JwtSecurityTokenHandler().WriteToken(token));
                result.Add(new JwtSecurityTokenHandler().WriteToken(refreshToken));

                return result;
            }
        }
    }
}
