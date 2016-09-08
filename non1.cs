#TouhouDanmakufu
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["Non 1"]
#Text["..."]
#BGM["./../lib/bgm/theme02.mp3"]

#include"./../lib/Libary.cs"

@Event{
    SetTimer(101);
    SetLife(20000);
    SetScore(1000000);
}
 
@Initialize{
	SetAutoDeleteObject(true);
	BOSS = ObjEnemy_Create(OBJ_ENEMY_BOSS);	
    ObjEnemy_Regist(BOSS);	
	AkariBossManage;
	AkariSprite;
	//Stage1BossAMusicName;
	//SPBG;
	MainTask;
}

@MainLoop{
	yield;
}

task MainTask{
	ObjMove_SetX(BOSS,GetCenterX);
	ObjMove_SetY(BOSS,GetCenterY-120);
	frame(60);
	ObjEnemy_SetDamageRate(BOSS,100,0);
	//fire;
	fire2;
	movement;
}

task movement{
	loop{
		ObjMove_SetDestAtSpeed(BOSS,GetCenterX+rand(-100,100),GetCenterY+rand(-30,-140),1);
		frame(300);
	}
}

task fire(dirP){
	let BN = 7;
	let dir = 0;
	let v=0.7;

	loop(10){
		SE_Play(shot,20);
	loop(BN){
	CreateShotA1(GetEnemyX+40*cos(dir), GetEnemyY+40*sin(dir), v, dir+dirP, PELLET_BLUE, 10);
	dir+=360/BN;
	}
	frame(5);
	dir+=rand(5,27);
	v+=0.2;
	}
	v=0.7;
	
}

task fire2{
	let dirP=90;
	loop{
	loop(1){
		famshot(GetAngleToPlayer(BOSS)+90, 10, GLOW_BLUE, S_TEAR_BLUE, TEAR_BLUE);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)-90, 10, GLOW_BLUE, S_TEAR_BLUE, TEAR_BLUE);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+90, 10, GLOW_AQUA, S_TEAR_AQUA, TEAR_AQUA);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)-90, 10, GLOW_AQUA, S_TEAR_AQUA, TEAR_AQUA);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+90, 10, GLOW_GREEN, S_TEAR_GREEN, TEAR_GREEN);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)-90, 10, GLOW_GREEN, S_TEAR_GREEN, TEAR_GREEN);
	}
	SE_Play(charge2,100);
	StarCharge("BLUE", GetEnemyX, GetEnemyY, 4, 0, 30, 1, 250, 100, 3, 2, 4);
	second(2);
	fire(dirP);
	if(dirP==90){dirP=-90;}
	else if(dirP==-90){dirP=90;}
	second(2);
	}
}

task fire3{
	loop{
	loop(1){
		famshot(GetAngleToPlayer(BOSS)+90, 5, GLOW_BLUE, TEAR_BLUE, S_TEAR_BLUE);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+90, 5, GLOW_AQUA, TEAR_AQUA, S_TEAR_AQUA);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+90, 5, GLOW_GREEN, TEAR_GREEN, S_TEAR_GREEN);
	}
	second(2);
	}
}

task famshot(dir, waitfornext, graphbig, graphplayer, graphotherway){
	let obj=CreateShotA1(GetEnemyX, GetEnemyY, 5, dir, graphbig, 10);
	Maineffect;
	loop(10){yield;}
	
	acion1;
	
	task acion1{
		while(!Obj_IsDeleted(obj)){
		SE_Play(shot,20);
		CreateShotA1(ObjMove_GetX(obj), ObjMove_GetY(obj), rand(0.6,3), GetAngleToPlayer(BOSS), graphplayer, 10);
		CreateShotA1(ObjMove_GetX(obj), ObjMove_GetY(obj), rand(0.6,3), GetAngleToPlayer(BOSS)+180, graphotherway, 10);
		loop(waitfornext){yield;}
	}
	}
	

	
	task Maineffect{
		Effect01;
		
		task Effect01{
			while(!Obj_IsDeleted(obj)){
			CreateMaineffect01;
			yield;
			}
		}

	
		task CreateMaineffect01{
			let alphaef=50;
			let scaleef=1;
			let time=10;
			let v=0;
			
			let objef = CreateShotA1(ObjMove_GetX(obj), ObjMove_GetY(obj), v, dir+180, graphbig, 0);
			loop(time){
			alphaef-=50/time;
			scaleef-=1/time;
			v+=0.4;
			ObjMove_SetSpeed(objef, v);
			ObjRender_SetAlpha(objef, alphaef);
			ObjRender_SetScaleXYZ(objef, scaleef, scaleef, 0);
			
			loop(5){yield;}
			}
			Obj_Delete(objef);
		}
		
	}
}












