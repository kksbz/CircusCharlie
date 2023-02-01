# CircusCharlie

2023-01-31 / v0.0.1 TitleScene setup    
2023-01-31 / v0.0.2 PlayerController Making
            Summary : jump시 중력적용 이슈발생
            Detail : 점프키 입력시 중력이 너무 크게 작용됨 값을 크게 줘도 엄청 느리게 점프하고 내려옴
            아직해결못함

2023-02-01 / v0.0.3 TitleScene TitelLogo Scrolling     
2023-02-01 / v0.1.0 PlayerMove Setup, v0.0.2 issue 해결
            Summary : v0.0.2 이슈 해결
            detail : 캐릭터 좌우이동을 Input.GetAxis()를 사용했는데
                    GetAxis()를 업데이트안에서 처리한게 문제였음
                    Input.GetKey()사용으로 해결함