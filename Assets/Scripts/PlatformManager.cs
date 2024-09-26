using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    List<Platform> platforms = new List<Platform>();

    float platformStartPosition;
    float platformDistance;

    int curPlatformIndex = -1;

    int preloadUpCount = 0;
    int preloadDownCount = 5;   //5개 정도가 적당할것같다.

    int preloadCount = 5;

    public void MakePlatforms(float _startPos, float _distance)
    {
        //카메라 영역의 크기를 가져온다 
        var _orthoSize = Camera.main.orthographicSize;

        //발판이 시작되는 위치부터 화면의 영역에 들어갈 발판의 갯수를 구한다
        var _screenHeight = (_orthoSize * 2) - _startPos;
        var _divideCount = (int)(_screenHeight / _distance);

        //화면에 보여질 발판외에 상단에 미리 생성해 놓을 발판의 갯수를 추가하여
        //캐릭터 기준으로 위로 몇개의 발판이 놓일지 정한다.
        preloadUpCount = _divideCount + preloadCount;

        //발판이 시작될 위치를 계산한다
        platformStartPosition = -_orthoSize + _startPos;
        //발판 사이의 거리를 지정한다
        platformDistance = _distance;

        Debug.Log("PreloadCount " + preloadUpCount);

        transform.position = Vector3.up * -_orthoSize;

        //만들어질 발판의 갯수를 정한다
        var _loopCount = preloadUpCount + preloadDownCount;
        var _platFormStartPos = _startPos - (_distance * preloadCount);

        Debug.Log("_loopCount : " + _loopCount);

        var _prefab = Resources.Load("PlatformNormal");
        for (int i = 0; i < _loopCount; i++)
        {
            var go = Instantiate(_prefab, transform) as GameObject;
            var _platform = go.GetComponent<Platform>();
            var _ypos = _platFormStartPos + (_distance * i);
            go.transform.localPosition = Vector3.up * _ypos;

            //발판의 순서를 정해준다
            _platform.SetPlatformIndex(i);

            platforms.Add(_platform);
        }

        //아래로 다섯개가 생기기 때문에 현재 위치는 5번째가 된다.
        curPlatformIndex = preloadDownCount;
    }

    //외부에서 타겟의 높이를 가져와서 현재 발판의 중심 위치를 갱신해준다
    public void UpdatePlatform(float _targetYposition)
    {
        var _diff = _targetYposition - platformStartPosition;
        var _index = (int)(_diff / platformDistance);

        //타겟의 위치에 밑에 배치되는 발판의 수를 더해서 배열상의 발판위치를 만들어준다
        _index += preloadDownCount;

        //Debug.Log("UpdateScroll : " + _diff);

        if (curPlatformIndex != _index)
        {
            bool _isUp = true;
            if (_index < curPlatformIndex)
            {
                _isUp = false;
            }
            curPlatformIndex = _index;

            SetPlatform(_isUp);
        }
    }

    //타겟의 이동방향에 따라서 발판을 재배치한다
    void SetPlatform(bool _isUp)
    {
        Debug.Log("SetPlatform : " + curPlatformIndex);

        int _moveCount = 0;
        if (_isUp == true)
        {
            var _diff = curPlatformIndex + (preloadUpCount - 1);
            Debug.Log("SetPlatform 1 : " + _diff);
            _moveCount = _diff - platforms[platforms.Count - 1].GetPlatformIndex;
            Debug.Log("SetPlatform 2 : " + _moveCount + " / " + platforms[platforms.Count - 1].GetPlatformIndex);
        }
        else
        {
            var _diff = curPlatformIndex - (preloadDownCount - 1);
            if (_diff <= 0) return;

            Debug.Log("down : " + _diff);
            _moveCount = platforms[0].GetPlatformIndex - _diff;
            Debug.Log("down _moveCount : " + _moveCount);
        }

        if (_isUp)
        {
            for (int i = 0; i < _moveCount; i++)
            {
                var _go = platforms[0];
                platforms.RemoveAt(0);
                var _endGo = platforms[platforms.Count - 1];
                platforms.Add(_go);
                //새로 배치된 위치 값으로 다시 지정 
                _go.SetPlatformIndex(_endGo.GetPlatformIndex + 1);
                _go.transform.localPosition = new Vector3(0, _endGo.transform.localPosition.y + platformDistance, 0);
            }
        }
        else
        {
            for (int i = 0; i < _moveCount; i++)
            {
                var _go = platforms[platforms.Count - 1];
                platforms.RemoveAt(platforms.Count - 1);
                var _startGo = platforms[0];
                platforms.Insert(0, _go);
                //새로 배치된 위치 값으로 다시 지정
                _go.SetPlatformIndex(_startGo.GetPlatformIndex - 1);
                _go.transform.localPosition = new Vector3(0, _startGo.transform.localPosition.y - platformDistance, 0);
            }
        }
    }
}
