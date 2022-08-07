using Sandbox;
using System;
using System.Linq;

namespace Sandbox;

partial class ZPVPawn : Player
{
	public enum ZPVTeamEnum
	{
		Unspecified,
		Spectator,
		Survivor,
		Infected,
		Undead
	}

	public enum ZombieType
	{
		Standard,
		Carrier
	} 

	public void SpawnToPoint(ZPVTeamEnum teamPoint = ZPVTeamEnum.Unspecified)
	{
		SpawnPoint spawnpoints = null;

		switch (teamPoint)
		{
			case ZPVTeamEnum.Unspecified:
				spawnpoints = Entity.All.OfType<SpawnPoint>().OrderBy( x => Guid.NewGuid() ).FirstOrDefault();
				break;
			case ZPVTeamEnum.Survivor:
				//TODO: Make survivor spawnpoints
				break;
			case ZPVTeamEnum.Undead:
				//TODO: Make zombie spawnpoints
				break;
		}

		if ( spawnpoints != null )
		{
			var tx = spawnpoints.Transform;
			tx.Position = tx.Position + Vector3.Up * 50.0f;
			Transform = tx;
		}
	}

	public void Infect()
	{

	}

	public override void Spawn()
	{
		base.Spawn();

		//Temporary, will use Zombie panic playermodels
		SetModel( "models/citizen/citizen.vmdl" );

		CameraMode = new FirstPersonCamera();
		Animator = new StandardPlayerAnimator();

		//Temporary, should make a game controller
		Controller = new WalkController();

		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );
		SimulateActiveChild( cl, ActiveChild );
	}

	public override void FrameSimulate( Client cl )
	{
		base.FrameSimulate( cl );
	}
}
