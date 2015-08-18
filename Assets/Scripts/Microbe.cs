using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Microbe : MonoBehaviour
{
	public enum Attribute{
		speed,
		strength,
		weight,
		turn_rate,
		resist_temperature,
		defense,
		regeneration,
		vision_range,
		vision_angle
	}
	
	private int attribute_base = 50;
	public Dictionary<Attribute,int> stat = new Dictionary<Attribute, int>();
	public int[][] bonus;
	public int[] total_bonus;

	public void Start()
	{
	}
	
	public void FixedUpdate()
	{
		
	}
	
	//Updates the current bonuses, and puts them into total_bonus
	public void UpdateBonusSum()
	{
		for (int i = 0; i < bonus.Length; i++)
		{
			int sum = 0;
			for (int j = 0; j < bonus[i].Length; j++)
			{
				sum += bonus[i][j];
			}
			total_bonus[i] = sum;
		}
	}
	
	public void NewData()
	{
		bonus = new int[][]
		{
			new int[] {100,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0},
			new int[] {0,0,0,0,0,0,0}
		};
		total_bonus = new int[] {0,0,0,0,0,0,0,0,0};
		UpdateBonusSum();
		stat[Attribute.speed] = attribute_base + total_bonus[0];
		stat[Attribute.strength] = attribute_base + total_bonus[1];
		stat[Attribute.weight] = attribute_base + total_bonus[2];
		stat[Attribute.turn_rate] = attribute_base + total_bonus[3];
		stat[Attribute.resist_temperature] = attribute_base + total_bonus[4];
		stat[Attribute.defense] = attribute_base + total_bonus[5];
		stat[Attribute.regeneration] = attribute_base + total_bonus[6];
		stat[Attribute.vision_range] = attribute_base + total_bonus[7];
		stat[Attribute.vision_angle] = attribute_base + total_bonus[8];
	}
}
