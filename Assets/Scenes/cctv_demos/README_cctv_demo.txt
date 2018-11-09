Created by David Lo 11/8/2018
pramslam@gmail.com
Feel free to contact me if you have any questions.

cctv_demo
These cctvs detect player collision. Used for stealth type mechanics. These cctvs do not have actual cameras in them.

* cctv_speed_demo:
- All cameras at 30degree tilt
- Left camera at 50% speed
- Middle camera at normal speed
- Right camera at 200% speed

This demo shows off the cctv's configurable panning speed. 
Set this variable by setting the values in the inspector for the CCTVSelector script.

* cctv_sweep_demo:
- First camera 30degree tilt, short sweep
- Second camera 30degree tilt, long sweep
- Third camera 45degree tilt, short sweep
- Fourth camera 45degree tilt, long sweep

This demo shows off the cctv's selectable sweep. Short 60degrees, or Long 75degrees.
See SETTING TILT AND SWEEP to setup this variable.

* cctv_tilt_demo:
- First camera shutdown
- Second camera 30degree tilt
- Third camera 45degree tilt
- Fourth camera 60degree tilt

This demo shows off the cctv's selectable tilt. You may choose between 30, 45, or 60 degrees of tilt.
See SETTING TILT AND SWEEP to setup this variable.

* SETTING TILT AND SWEEP:
Set these variables by setting the values in the inspector for the CCTVSelector script.
Format for cameratype vaule is camera tilt angle(30,45,60) then sweep(0,1)
Example: 30deg tilt, short sweep is = 300, long sweep is = 301
         45deg tilt, short sweep is = 450, long sweep is = 451
         60deg tilt, short sweep is = 600, long sweep is = 601