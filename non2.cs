#TouhouDanmakufu
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["Non 2"]
#Text["..."]
#BGM["./../lib/bgm/theme02.mp3"]

#include"./../lib/Libary.cs"

@Event{
    SetTimer(101);
    SetLife(30000);
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
	ObjMove_SetDestAtFrame(BOSS,GetCenterX, GetCenterY-120, 40);
	frame(60);
	ObjEnemy_SetDamageRate(BOSS,100,0);
	//fire;
	fire2;
	movement;
}

task movement{
	loop{
		ObjMove_SetDestAtSpeed(BOSS,GetCenterX+rand(-100,100),GetCenterY+rand(-80,-140),1);
		frame(300);
	}
}

task fire(dirP){
	let BN = 1;
	let dir = 0;
	let v=1.7;

	loop(50){
		SE_Play(shot,20);
	loop(BN){
	let shoot1 = CreateShotA2(GetEnemyX+40*cos(dir), GetEnemyY+40*sin(dir), v, dir+dirP, -0.04, 0, S_BLUBBLE_BLUE, 10);
	ObjMove_AddPatternA2(shoot1, 120, 0, NO_CHANGE, 0.01, 0, v);
	dir+=360/BN;
	}
	frame(1);
	dir+=rand(5,27);
	v+=0.07;
	}
	v=1.7;
}

task fire2{
	let dirP=90;
	loop{
	loop(1){
		famshot(GetAngleToPlayer(BOSS)+70, 10, GLOW_BLUE, S_TEAR_BLUE, TEAR_BLUE);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+110, 10, GLOW_AQUA, S_TEAR_AQUA, TEAR_AQUA);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+70, 10, GLOW_BLUE, S_TEAR_BLUE, TEAR_BLUE);
		frame(30);
		famshot(GetAngleToPlayer(BOSS)+110, 10, GLOW_AQUA, S_TEAR_AQUA, TEAR_AQUA);
	}
	SE_Play(charge2,100);
	StarCharge("BLUE", GetEnemyX, GetEnemyY, 7, 0, 30, 1, 250, 100, 3, 2, 4);
	second(2);
	loop(2){
	fire(dirP);
	if(dirP==90){dirP=-90;}
	else if(dirP==-90){dirP=90;}
	frame(60);
	}
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
	let obj2=CreateShotA1(GetEnemyX, GetEnemyY, 5, dir+180, graphbig, 10);
	Maineffect;
	loop(10){yield;}
	
	acion1;
	acion2;
	
	task acion1{
		while(!Obj_IsDeleted(obj)){
		SE_Play(shot,20);
		CreateShotA1(ObjMove_GetX(obj), ObjMove_GetY(obj), rand(1,3), GetAngleToPlayer(BOSS), graphplayer, 10);
		CreateShotA1(ObjMove_GetX(obj), ObjMove_GetY(obj), rand(1,3), GetAngleToPlayer(BOSS)+180, graphotherway, 10);
		loop(waitfornext){yield;}
	}
	}
	
	task acion2{
		while(!Obj_IsDeleted(obj2)){
		SE_Play(shot,20);
		CreateShotA1(ObjMove_GetX(obj2), ObjMove_GetY(obj2), rand(1,3), GetAngleToPlayer(BOSS), graphplayer, 10);
		CreateShotA1(ObjMove_GetX(obj2), ObjMove_GetY(obj2), rand(1,3), GetAngleToPlayer(BOSS)+180, graphotherway, 10);
		loop(waitfornext){yield;}
	}
	}
	
	task Maineffect{
		Effect01;
		Effect02;
		
		task Effect01{
			while(!Obj_IsDeleted(obj)){
			CreateMaineffect01;
			yield;
			}
		}
		task Effect02{
			while(!Obj_IsDeleted(obj2)){
			CreateMaineffect02;
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
		
		task CreateMaineffect02{
			let alphaef=50;
			let scaleef=1;
			let time=10;
			let v=0;
			
			let objef2 = CreateShotA1(ObjMove_GetX(obj2), ObjMove_GetY(obj2), v, dir+180, graphbig, 0);
			loop(time){
			alphaef-=50/time;
			scaleef-=1/time;
			v+=0.4;
			
			ObjMove_SetSpeed(objef2, v);
			ObjRender_SetAlpha(objef2, alphaef);
			ObjRender_SetScaleXYZ(objef2, scaleef, scaleef, 0);
			loop(5){yield;}
			}
			Obj_Delete(objef2);
		}
	}
}












