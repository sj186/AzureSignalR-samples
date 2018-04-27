// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Azure.SignalR.Samples.ChatRoom
{
    [Route("/")]
    public class AuthController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(GitHubAuthenticationDefaults.AuthenticationScheme);
            }

            HttpContext.Response.Cookies.Append("githubchat_username", User.Identity.Name);
            return Redirect("/");
        }
    }
}
