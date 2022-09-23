# Unity3d-Simple-Physics-Sample
实现过的简单物理效果集合

>1. 监视器之类的东西盯着某物体旋转
![动画](https://user-images.githubusercontent.com/25300766/191911372-dd9251d2-2cb7-48a6-9d6c-c0b054bd0706.gif)
 MonitorPlayer.cs
 麻烦的点在于被旋转的物体一定要加一级父物体，把子物体的方向自行设置之后，旋转这个父物体。这是由于子物体的模型正方向受模型本身影响。
![image](https://user-images.githubusercontent.com/25300766/191911685-3d875867-411b-49ec-9350-af693eb8a1db.png)
