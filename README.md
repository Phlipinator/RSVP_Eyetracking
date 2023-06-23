# About #
This adaptive RSVP demo was created by Philipp Thalhammer and can be used by anyone.  
For the setup a *HTC Vive Pro Eye* was used.

# General Setup #
You will need to install the following software:
- Unity
- SRanipal Eye Tracking SDK (for Unity)
(if Unity crashed try using a older version of the SDK like described here:  
https://forum.htc.com/topic/14152-vive-eye-tracking-sdk-makes-unity-project-crashing/)
- SRanipal Runtime
(if you get an error message try the approach described here:  
https://forum.htc.com/topic/10439-vive-sranipal-installer-installation-failed-error-1001-the-system-cannot-find-the-file-specified)
- Steam VR

For the basic setup on your PC AND in Unity just follow the tutorial found here:  
https://developer.tobii.com/xr/develop/xr-sdk/getting-started/vive-pro-eye/

# Scenes #
Under *Assets/ViveSR/Scenes/Eye* you can find two Sample scenes provided by the SDK that show a basic mirror avatar to check if eye tracking is working properly.  
The other relevant scenes can be found under *Assets/Scenes*

## Pupil Dilation ##
This Scene is just a quick demonstrator to display the Left and Right Pupil dilation in mm in realtime.  
There is no need to adjust anything.

## RSVP ##
All data this Scene collects is saved under *Assets/CSV*. Currently the *calculation method*, *background color*, *speed in WPM*, *phase* (either calibration or testing), *left pupil Dilation*, *right pupil Dilation* and the *gaze position* are saved under *participant_ID.cvs*.
This scene offers a lot of customization within the editor. Everything can be adjusted on the *Manager*-Object within the scene.  

### Simple_RSVP ###
#### Speed ####
Adjust the speed in words per minute

#### Start Pause ####
Adjust the initial pause timer at the beginning (in seconds)

#### Text File ####
Specify a Textfile (1-10) to be used during testing.

#### Use random Textfile ####
Uses a random Textfile instead of a specified one. Overrides *Textfile* when active.

### Data Export ###
#### Participant_ID ####
Specifies the Participant ID in the created *CSV-File*

#### Calculation Method ####
Can either be *A* to use the average eye data or *L* / *R* to use Left or Right eye data.

#### Backgorund Color ####
Can either be *W* for white background with grey text, *G* for grey background with black text or *B* for black background with grey text.

### Gaze Position Calculator ###
#### Gaze Target ####
Needs to be assigned the Text-Object.

#### Pointer ####
Needs to be assigned the Poinzter Object (could be any 3D object).

#### Show Pointer ####
Toggle Pointer on or off.

### Environment Changer ###
#### BG ####
Needs to be assigned the BG-Object.

#### RSVP ####
Neds to be assigned the Text-Object.

#### White/Grey/Black BG ####
Need to be assigned to the respective Materials.