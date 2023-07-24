# Part-Colorizer-for-Solid-Edge

Still a work in progress

<img src="Main Form.png">

**Fast Mode (Create FaceStyles but don't apply to faces):** With this option checked the FaceStyles created during faces parsing will not be applied to the related faces

ToDo: Investigate why performances slow down while applying FaceStyles to faces
- Open in background doesn't speed up the process
- Application.Interactive to false doesn't speed up the process
- Application.ScreenUpdating to false doesn't speed up the process
- Application.DelayCompute to true doesn't speed up the process
