#TouhouDanmakufu
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["SC 3"]
#Text["..."]
#BGM["./../lib/bgm/theme02.mp3"]

#include"./../lib/Libary.cs"

@Event{
    SetTimer(201);
    SetLife(10000);
    SetScore(1000000);
}
 
@Initialize{
	SetAutoDeleteObject(true);
	BOSS = ObjEnemy_Create(OBJ_ENEMY_BOSS);	
    ObjEnemy_Regist(BOSS);	
	AkariBossManage;
	AkariSprite;
	Spellcard01;
	MainTask;
}

@MainLoop{
	yield;
}

task MainTask{
	ObjMove_SetDestAtSpeed(BOSS,GetCenterX,GetCenterY,3);
	frame(240);
	fire;
	fire2;
	movement;
	second(2);
	ObjEnemy_SetDamageRate(BOSS,30,0);
}

task movement{
	loop{
		ObjMove_SetDestAtSpeed(BOSS,GetCenterX+rand(-100,100),GetCenterY+rand(-100,-140),1);
		frame(400);
	}
}

task fire{
	let BN=7;
	let dir=0;
	let circles=1;
	
	loop{
		SE_Play(wave,60);
	loop(BN){
		CreateLooseLaserA1(GetEnemyX+25*cos(dir), GetEnemyY+25*sin(dir), 3, dir, 100, 10, ARROWHEAD_PURPLE, 20);
		dir+=360/BN;
	}
	dir+=23;
	frame(20);
	}
}

task fire2{
	let BN=5;
	let dir=0;
	let circles=1;
	
	loop{
		SE_Play(wave,60);
	loop(BN){
		CreateLooseLaserA1(GetCenterX+250*cos(dir), MinY+1*sin(dir), 3, rand(90,110), 140, 5, ARROWHEAD_AQUA, 20);
		dir+=360/BN;
	}
	dir+=230;
	frame(20);
	}
}







