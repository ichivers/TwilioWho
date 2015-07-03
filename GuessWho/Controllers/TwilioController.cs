using GuessWho.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Twilio;

namespace GuessWho.Controllers
{
    public class TwilioController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ReceiveSMS(SmsMessage smsMessage)
        {
            Services services = new Services(smsMessage);           
                services.SaveMessage(smsMessage);
                var twilio = new TwilioRestClient(ConfigurationManager.AppSettings["TwilioAccountKey"],
                    ConfigurationManager.AppSettings["TwilioAuthToken"]);
                if (smsMessage.Body.ToLower().StartsWith("play"))
                {
                   services.CreateGame(smsMessage);
                    twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                        smsMessage.From,
                        smsMessage.Body.Substring(smsMessage.Body.ToLower().IndexOf("play") + 4) +
                        ", I'm ready for your first question!");
                }
                else
                {                   
                    if (services.Game == null)
                    {
                        twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Sorry, I can't find your game.");
                        return Ok();
                    }                    
                    if (services.Character == null)
                    {
                        twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Sorry, I can't find the character your game started with.");
                        return Ok();
                    }
                    if (smsMessage.Body.ToLower().StartsWith("male"))                    
                    {
                        Respond(services.gender(Gender.male), smsMessage, twilio);                        
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("female"))
                    {
                        Respond(services.gender(Gender.female), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("hair"))
                    {
                        if (services.hair(smsMessage.Body.Substring(5)))
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Yes.");
                        }
                        else
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "No.");
                        }
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("eyes"))
                    {
                        if (services.eyes(smsMessage.Body.Substring(5)))
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Yes.");
                        }
                        else
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "No.");
                        }
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("hat"))
                    {
                        Respond(services.hat(), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("beard"))
                    {
                        Respond(services.beard(), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("glasses"))
                    {
                        Respond(services.glasses(), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("moustache"))
                    {
                        Respond(services.moustache(), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("bald"))
                    {
                        Respond(services.bald(), smsMessage, twilio);
                        services.Update();
                    }
                    else if (smsMessage.Body.ToLower().StartsWith("is it"))
                    {
                        if (services.guess(smsMessage.Body.Substring(6)))
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Congratulations, you guessed right in " + services.Game.Turns.ToString() + ".");
                        }
                        else
                        {
                            twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Sorry, you guessed wrong.  The answer was " + services.Game.Character);
                        }
                        services.Update();
                    }
                    else
                    {
                        twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                                smsMessage.From,
                                "Sorry, I didn't understand your message.");
                    }
                }
                return Ok();            
        }

        private void Respond(bool result, SmsMessage smsMessage, TwilioRestClient twilio)
        {           
             if(result)
             {
                 twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                     smsMessage.From,
                     "Yes.");
             }
             else
             {
                 twilio.SendMessage(ConfigurationManager.AppSettings["TwilioNumber"],
                     smsMessage.From,
                     "No.");
             }             
        }
    }
}
