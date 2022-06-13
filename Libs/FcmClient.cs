using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using SurveyConsole.Models;

namespace SurveyConsole.Libs
{
    public class FcmClient
    {
        private FirebaseApp _fapp;
        private static FirebaseApp fapp;
        private AppsSettings _appSettings = new AppsSettings();

        public FcmClient(String googleCredential)
        {
            try
            {
                if(!(this._fapp is FirebaseApp))
                {
                    this._fapp = FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(googleCredential)
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Failed to initialize FirebaseApp instance!");
            }
        }

        //public FcmClient(IConfiguration configuration)
        //{
        //    configuration.Bind(_appSettings);
        //    try
        //    {
        //        this._fapp = FirebaseApp.Create(new AppOptions()
        //        {
        //            Credential = GoogleCredential.FromFile(_appSettings.CustomConfig.GoogleCredential)
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Failed to initialize FirebaseApp instance!");
        //    }
        //}

        public String SendNotification(String destinationToken, Dictionary<string, string> data)
        {
            try
            {
                var message = new Message()
                {
                    Data = data,
                    Token = destinationToken
                };

                string response = (FirebaseMessaging.GetMessaging(this._fapp)).SendAsync(message).Result;

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static String SendNotification(String destinationToken, Dictionary<string, string> data, String googleCredential)
        {
            string response;

            if (!(fapp is FirebaseApp))
            {
                fapp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(googleCredential),
                    ProjectId = "mobilesurvey2021",
                    ServiceAccountId = "firebase-adminsdk-xxspm@mobilesurvey2021.iam.gserviceaccount.com"
                });
            }

            var message = new Message()
            {
                Data = data,
                Token = destinationToken
            };

            response = (FirebaseMessaging.GetMessaging(fapp)).SendAsync(message).Result;

            return response;
        }
    }
}
