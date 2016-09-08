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
