using Godot;
using System;
public partial class Ability : Node2D
{
	public float CD;
	public float use_time;
	public float cost;
	public Timer useTimer;
	public Timer CDTimer;
	
	protected bool CanUse;
	
	protected virtual void Use(entity Obj){}
	
	
	void _on_tree_entered()
	{
		GD.Print("Entered");
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
	}
	
	
	public void UseAbility(entity Obj)
	{
		if (CanUse){
			useTimer.Start();
			GD.Print("dashed ", CD);
			Use(Obj);
		}
	}

	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			CanUse = true;
		}
	}
	protected Ability(float cd, float uset, float ct){
		GD.Print("right constr");
		CD = cd;
		use_time = uset;
		cost = ct;
		CanUse = true;
		//useTimer.WaitTime = use_time;
		//CDTimer.WaitTime = CD;
	}
	protected void _on_use_timer_timeout()
	{
		GD.Print("use_t timeout");
		CDTimer.Start();
		CanUse = false;
	}

	protected void _on_cd_timer_timeout()
	{
		GD.Print("cd_t timeout");
		CanUse = true;
	}
	public Ability(){
		GD.Print("wrong constr");
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
	}
}
