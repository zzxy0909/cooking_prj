using UnityEngine;
using System.Collections;

// 게임 오브잭트에서 CookingEventRecipeGroup 과 CookingEventItemBase 등에 연결된 인댁스 관리.
// 플레이 속도나 퍼포먼스 고려 하여 향후 동적 관리 계획.
public enum E_RecipeEnum
{
    // 레시피 인댁스 공통
    Hotdog = 0, // 핫도그
    Hamburger, // 햄버거
}
public enum E_Worktops_Hotdog
{
    ChoppingBoard = 0, // 도마
    Dish = 1, // 접시
}
public enum E_Worktops_Hamburger
{
    ChoppingBoard = 0, // 도마
    Dish = 1, // 접시
}

public enum E_HotDogSeq
{
    S01_0_Material_preparation, // 재료 준비 
    S01_1, // 양배추 도마로 보내기
    S01_2, // 빵 오븐으로
    S01_3, // 소시지 프라이팬으로
     
}