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
                    GetAxis()를 방어로직없이 업데이트문 안에서 사용하면
                    그값이 0이아닌 0의 근사값이 프레임마다 넘어오기 때문에
                    점프후 느리게 내려오는 것이였음
                    Input.GetKey()사용으로 해결함
2023-02-02 / v0.2.0 Scrolling Background setup    
2023-02-02 / v0.3.0 Scrolling Fence Setup
                Summary : 장애물이 런타임때 생성, 장애물의 포지션값이 필요     
                detail : 장애물의 RectTrancform의 anchoredPosition.x값이 필요함
                        움직이는 장애물의 갱신되는 anchoredPosition.x값을 계속받아야하는데 해결못함    
                        