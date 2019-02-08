# AutoLockFeature
A C# (.Net) forms piece of software to Lock your computer automatically if idle after a set time (initial 3 minutes)

This program is free to be used by any interested parties. If you'd like to modify it, that's fine, but do so at your own risk.
I'm not responsible for any harm caused by the use of this program, but I'd say it's pretty harmless. It keeps a timer ticking every 5
seconds until the set limit is reached. If the computer has been idle for that much, it locks your workstation.
I felt the need to write this because the company I currently work for (as of 2019) has a policy you need to lock your workstation if you
leave your desk. I often forget, so I'll just have this program running and it locks it up for me.

It uses the Windows API,so it'll probably be useful only in a Windows environment, post MS Windows 2000.

Features I'd like to implement:
Checking if workstation is locked and bypassing the tick if so.
Adjust the tick if set to less than 5 seconds (though I don't see the need).
Validate if the entered number of seconds is a number. It'll break if it's not. But hey, not like you didn't know it's supposed to be 
a number, right?

* MS Windows, Windows, MS, Microsoft are trademarks owned by other parties and I claim no ownership on them. Legal mumble-jumble, just trying to be fine here.
