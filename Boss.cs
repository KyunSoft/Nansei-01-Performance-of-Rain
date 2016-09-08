#TouhouDanmakufu[Plural]
#ScriptVersion[3]
#System["./../../../default_system/Default_System.txt"]
#Title["Akari"]
#BGM["./../lib/bgm/theme02.mp3"]

#include"./../lib/Libary_Difficulty.cs"
#include"./backgroundstg1.txt"

let CSD=GetCurrentScriptDirectory();


@Initialize{
	TPlural;
	CreateRankIco("EXTRA");
	//Background;
	TBackgroundStg;
	SetPlayerLife(99);
	SetPlayerSpell(5);
	SetPauseScriptPath(CSD ~ "./../../../default_system/Default_Pause.txt");
	SetEndSceneScriptPath(CSD ~ "./../../../default_system/Default_EndScene.txt");
}

@Event{
}

@MainLoop{
	yield;
}

task TPlural
{
	loop(20){yield}
	let obj=ObjEnemyBossScene_Create();

	ObjEnemyBossScene_Add(obj,1,CSD~"non1.cs");
	ObjEnemyBossScene_Add(obj,1,CSD~"spell1.cs");
	ObjEnemyBossScene_Add(obj,2,CSD~"non2.cs");
	ObjEnemyBossScene_Add(obj,2,CSD~"spell2.cs");
	ObjEnemyBossScene_Add(obj,3,CSD~"spell3.cs");

	ObjEnemyBossScene_LoadInThread(obj);
	ObjEnemyBossScene_Regist(obj);
	while(!Obj_IsDeleted(obj))
	{
		yield;
	}
	CloseScript(GetOwnScriptID());
}

task Background{
	let BG0 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg0.png";	
	let BG1 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg1.png";	
	let BG2 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg2.png";	
	let BG3 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg3.png";	
	let BG4 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg4.png";
	let BG5 = GetCurrentScriptDirectory ~ "./../lib/img/World/stg6/stgbg5.png";

	Back;
	Front;

	task Back{
		let RecTY=0;
		let RecTY2=0;
		let objfog = ObjPrim_Create(OBJ_SPRITE_2D);
		ObjPrim_SetTexture(objfog, BG0); 
		Obj_SetRenderPriorityI(objfog, 22);
		ObjSprite2D_SetSourceRect(objfog,0,0,400,450);
		ObjSprite2D_SetDestRect(objfog,0,0,400,450);
		ObjRender_SetAlpha(objfog,255);
		
		let objback = ObjPrim_Create(OBJ_SPRITE_2D);
		ObjPrim_SetTexture(objback, BG4); 
		Obj_SetRenderPriorityI(objback, 22);
		ObjSprite2D_SetSourceRect(objback,0,0,400,450);
		ObjSprite2D_SetDestRect(objback,0,0,400,450);
		ObjRender_SetAlpha(objback,205);
		
		let objback2 = ObjPrim_Create(OBJ_SPRITE_2D);
		ObjPrim_SetTexture(objback2, BG5); 
		Obj_SetRenderPriorityI(objback2, 22);
		ObjSprite2D_SetSourceRect(objback2,0,0,400,450);
		ObjSprite2D_SetDestRect(objback2,0,0,400,450);
		ObjRender_SetAlpha(objback2,205);
		ObjRender_SetScaleXYZ(objback2,1,1,0);
		
		loop{
			ObjSprite2D_SetSourceRect(objback,0,0+RecTY,400,450+RecTY);
			ObjSprite2D_SetSourceRect(objback2,0,0+RecTY2,400,450+RecTY2);
			RecTY-=0.5;
			RecTY2-=0.7;
			yield;
		}
	}
	
	task Front{
		let RecTY=0;
		let RecTY2=0;
		let objfront = ObjPrim_Create(OBJ_SPRITE_2D);
		ObjPrim_SetTexture(objfront, BG2); 
		Obj_SetRenderPriorityI(objfront, 22);
		ObjSprite2D_SetSourceRect(objfront,0,0,400,450);
		ObjSprite2D_SetDestRect(objfront,0,0,400,450);
		ObjRender_SetAlpha(objfront,205);
		
		let objfront2 = ObjPrim_Create(OBJ_SPRITE_2D);
		ObjPrim_SetTexture(objfront2, BG1); 
		Obj_SetRenderPriorityI(objfront2, 52);
		ObjSprite2D_SetSourceRect(objfront2,0,0,400,450);
		ObjSprite2D_SetDestRect(objfront2,0,0,400,450);
		ObjRender_SetAlpha(objfront2,205);
		
		loop{
			ObjSprite2D_SetSourceRect(objfront,0,0+RecTY,400,450+RecTY);
			ObjSprite2D_SetSourceRect(objfront2,0,0+RecTY2,400,450+RecTY2);
			RecTY-=2;
			RecTY2-=4;
			yield;
			if(ObjEnemyBossScene_GetInfo(GetEnemyBossSceneObjectID(), INFO_IS_SPELL)){
				ObjRender_SetAlpha(objfront2,0);
			}
			else{
				ObjRender_SetAlpha(objfront2,205);
			}
		}
	}
}