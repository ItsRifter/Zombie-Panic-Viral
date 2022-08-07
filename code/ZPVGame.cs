using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public partial class ZPVGame : Sandbox.Game
{
	public ZPVGame()
	{

	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var pawn = new ZPVPawn();
		pawn.Spawn();
		client.Pawn = pawn;
	}
}
