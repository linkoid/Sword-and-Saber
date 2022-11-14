using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PirateGame.UI
{
	public class HUD : MonoBehaviour
	{
		[SerializeField] Player m_Player;
		public Slider HealthBar;
		public TMP_Text Loot_Text, Crew_Text, Too_Poor;

		public bool Buy(int cost)
		{
			var value = m_Player.Gold;
			m_Player.Gold = m_Player.Gold >= cost ? m_Player.Gold - cost : m_Player.Gold;
			return value >= cost;
		}

		public void RepairShip()
		{
			if (m_Player.Health == m_Player.MaxHealth)
			{
				return;
			}
			m_Player.Health = Buy(3) ? m_Player.MaxHealth : m_Player.Health;
		}

		public void AddCrew()
		{
			m_Player.CrewCount += Buy(5) ? 1 : 0;
		}


		public void AddSpeed()
		{
			m_Player.SpeedMod += Buy(20) ? 1 : 0; ;
		}

		// Start is called before the first frame update
		void Start()
		{

			HealthBar.minValue = 0;
		}

		// Update is called once per frame
		void Update()
		{

			Loot_Text.text = m_Player.Gold.ToString();

			Crew_Text.text = m_Player.CrewCount.ToString();

			if (HealthBar.maxValue != m_Player.MaxHealth)
			{
				HealthBar.maxValue = m_Player.MaxHealth;
			}
			float valueDif = m_Player.Health - HealthBar.value;
			HealthBar.value += valueDif * .01f;
		}
	}
}