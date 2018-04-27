using System;
using System.Collections.Generic;

public static class AppController
{
	private static Dictionary<int, int> enemiesDestroyed = new Dictionary<int, int>();
	private static int enemiesCountForAnswer = 5;

//		public AppController ()
//		{
//		}

	public static void InformEnemyDestroyed(Enemy_Clase enemy) {
		if (enemiesDestroyed.ContainsKey (enemy.Enemy_Color) == false)
			enemiesDestroyed.Add (enemy.Enemy_Color, 0);

		enemiesDestroyed [enemy.Enemy_Color]++;

		CheckEnemiesDestroyedCount (enemy);
	}

	private static void CheckEnemiesDestroyedCount(Enemy_Clase enemy) {
		if (enemiesDestroyed [enemy.Enemy_Color] >= enemiesCountForAnswer) {
			MostrarPreguntas.Instance.DisplayNextQuestion ();

			ResetEnemiesStatistics ();
		}
	}
	private static void ResetEnemiesStatistics() {
		enemiesDestroyed = new Dictionary<int, int> ();
	}
}

