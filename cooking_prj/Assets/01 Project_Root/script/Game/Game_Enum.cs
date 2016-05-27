using UnityEngine;
using System.Collections;

// 게임 오브잭트에서 CookingEventRecipeGroup 과 CookingEventItemBase 등에 연결된 인댁스 관리.
// 플레이 속도나 퍼포먼스 고려 하여 향후 동적 관리 계획.
public enum E_RecipeEnum
{
    // 레시피 인댁스 공통
    Hotdog = 0, // 핫도그
    Hamburger, // 햄버거

    None = 999 // 무 설정.
}
public enum E_CookMaterial
{
    // R000 레시피 인댁스 _ 재료번호 _ 스페셜 번호
    R000_01_00, // 핫도그 기본 야체
    R000_02_00, // 핫도그 기본 빵
    R000_03_00, // 핫도그 기본 소시지

}

public enum E_Worktops_HotDog
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
    // R000 레시피 인댁스 _ 010 시퀀스 번호 _ 세부 설정 상태 번호
    R000_010_00, // 주 재료 준비 - 0,1,2 재료 클릭 설정 상태 준비
    R000_010_10, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    R000_010_11, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 중 대기 
    R000_010_20, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 리셋 시작
    R000_020, // 양배추 도마로 보내기
    R000_030, // 빵 오븐으로
    R000_040, // 소시지 프라이팬으로     
}
public enum E_HumburgerSeq
{
    // R000 레시피 인댁스 _ 010 시퀀스 번호 _ 세부 설정 상태 번호
    R000_010_00, // 주 재료 준비 - 0,1,2 재료 클릭 설정 상태 준비
    R000_010_10, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    R000_010_11, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 중 대기 
    R000_010_20, // 주 재료 준비 0,1,2 재료 클릭 설정 상태 리셋 시작
    R000_020, // 양배추 도마로 보내기
    R000_030, // 빵 오븐으로
    R000_040, // 소시지 프라이팬으로     
}

public enum E_CookingItemGroupType
{
    CookingMatrial, // 제료.
    CookingTool, // 도구 ( 칼, 집개 등)
    CookingEquip, // 장비 (가스렌지, 도마, 오븐 등)
}

public enum E_CookingItemType
{
    vegetable, // 야채
    bread, // 빵
    sausage, // 소시지

}
