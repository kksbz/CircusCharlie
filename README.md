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
2023-02-03 / v0.5.0 Fix Scrolling Fence Setup
                Summary : 장애물 포지션값 필요
                detail : 장애물의 anchoredPosition.x값이 필요하지 않은 문제였음
                         플레이어가 움직이는 값만큼 장애물위치값을 같이 변경하는 방법으로
                         장애물이 다가오거나 멀어지거나를 구현가능했음     
2023-02-03 / v1.0.0 Fix FenceObj Setup, Stage1 complete    
2023-02-04 / v1.1.0 EndScene setup
                Summart : 게임오버시 게임오버창 출력
                detail : 처음 구현시 게임오버시 스테이지씬 안에있는 게임오버이미지오브젝트를 팝업시키는방식으로 구현
                         모든 스테이지에서 게임오버창을 공유해야 되는 문제를 해결하기 위해 새로운 Scene을 만듬
                         EndScene을 만들어 씬전환으로 게임오버창을 구현함 EndScene에서 타이틀씬으로 이동가능하게 구현
                         
                        