using Discord;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordRichPresence : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        int secondsSinceEpoch = (int)t.TotalSeconds;

        discord = new Discord.Discord(928450421461246003, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Testing Game",
            Details = "Writing C# and more",
            Assets =
            {
                LargeImage = "hellorein",
                LargeText = "Game Test"
            },
            Timestamps =
            {
                Start = secondsSinceEpoch
            }
        };

        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord Rich Presence is running");
            }
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}
