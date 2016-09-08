#TouhouDanmakufu
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["SC 2"]
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
	//fire;
	BottleFamiliar;
	movement;
	second(2);
	ObjEnemy_SetDamageRate(BOSS,30,0);
}

task movement{
	loop{
		ObjMove_SetDestAtSpeed(BOSS,GetCenterX+rand(-100,100),GetCenterY+rand(-100,-140),1);
		frame(300);
	}
}

task fire{
	let BN=5;
	let dir=0;
	let circles=3;
	
	loop{
	loop(BN){ascent(c in 0..circles){
		CreateShotA1(GetEnemyX, GetEnemyY, 1+(c*0.5), dir, GLOW_YELLOW, 20);
		}
		dir+=360/BN;
	}
	dir+=180;
	second(2);
	}
}

task BottleFamiliar{
	let spin=-40;

	let obj = ObjEnemy_Create(OBJ_ENEMY);
	ObjEnemy_Regist(obj);
	ObjPrim_SetTexture(obj,BottleFam2);
	Obj_SetRenderPriorityI(obj,45);
	ObjSprite2D_SetSourceRect(obj,0,0,115,140);
	ObjSprite2D_SetDestCenter(obj);
	ObjRender_SetScaleXYZ(obj,0.6,0.6,0);
	//ObjRender_SetBlendType(obj,BLEND_ADD_RGB);
	ObjRender_SetAngleXYZ(obj,0,0,spin);
	ObjRender_SetAlpha(obj, 255);
	ObjRender_SetPosition(obj, GetEnemyX, GetEnemyY, 0);
	
	spinning;
	Famfire;
	
	while(!Obj_IsDeleted(obj)){
		yield;
	}
	
	Obj_Delete(obj);
	
	task spinning{
		while(!Obj_IsDeleted(obj)){
			loop(40){
				ObjRender_SetAngleXYZ(obj,0,0,spin);
				spin+=2;
				yield;
			}
			loop(40){
				ObjRender_SetAngleXYZ(obj,0,0,spin);
				spin-=2;
				yield;
			}
		}
	}
	
	
	task Famfire{
		let BN=3;
		let dir=3;
		let direction=0;
		let dis=0;
		
		loop{
			direction+=rand(0,360);
			dis=0;
		loop(50){
			SE_Play(wave,60);
		loop(BN){
			let famshoot=CreateShotA1(ObjMove_GetX(obj)+dis*cos(dir), ObjMove_GetY(obj)+dis*sin(dir), 0, direction, SMALL_BLUE, 40);
			ObjMove_AddPatternA2(famshoot, 100, 0, direction, 0.03, 0, 1);
			dir+=360/BN;
		}
		frame(3);
		dir+=20;
		dis+=400/50;
		}
		second(1);
		
			direction+=rand(0,360);
			dis=0;
		loop(50){
			SE_Play(wave,60);
		loop(BN){
			let famshoot=CreateShotA1(ObjMove_GetX(obj)+dis*cos(dir), ObjMove_GetY(obj)+dis*sin(dir), 0, direction, SMALL_ORANGE, 40);
			ObjMove_AddPatternA2(famshoot, 100, 0, direction, 0.03, 0, 1.5);
			dir+=360/BN;
		}
		frame(3);
		dir+=-35;
		dis+=400/50;
		}
		second(1);
		}
	}
}




















