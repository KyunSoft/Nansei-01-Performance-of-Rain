#TouhouDanmakufu
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["SC 1"]
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
	let spin=-20;

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
	ActionMain;
	
	while(!Obj_IsDeleted(obj)){
		yield;
	}
	
	Obj_Delete(obj);
	
	task spinning{
		while(!Obj_IsDeleted(obj)){
			loop(40){
				ObjRender_SetAngleXYZ(obj,0,0,spin);
				spin+=1;
				yield;
			}
			loop(40){
				ObjRender_SetAngleXYZ(obj,0,0,spin);
				spin-=1;
				yield;
			}
		}
	}
	
	
	task ActionMain{
		ObjMove_SetDestAtFrame(obj, MinX+20, 80, 60);
		second(1);
		Famfire;
		loop{
			ObjMove_SetDestAtFrame(obj, MaxX-20, 80, 300);
			frame(300);
			ObjMove_SetDestAtFrame(obj, MinX+20, 80, 300);
			frame(300);
		}
	}
	
	task Famfire{
		let BN=3;
		let angle=3;
		
		loop{
			SE_Play(wave,50);
		loop(BN){
			let famshoot=CreateShotA2(ObjMove_GetX(obj)+40*cos(angle), ObjMove_GetY(obj)+40*sin(angle)-40, rand(1,3), rand(260,280), -0.04, 0, PELLET_BLUE, 10);
			ObjShot_SetAutoDelete(famshoot, false);
			ObjShot_SetSpellResist(famshoot, true);
			ObjMove_AddPatternA2(famshoot, 40, 0, rand(80,100), 0.04, 0, rand(2,4));
			angle+=360/BN;
		}
		angle+=rand(10,30);
		frame(10);
		}
	}
}




















