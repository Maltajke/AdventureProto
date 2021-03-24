using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Utils.SeparateThreadExecutor.Impl;
using Ping = System.Net.NetworkInformation.Ping;

namespace Tests
{
    public class DebugView : MonoBehaviour
    {
        [SerializeField] private Text IsValid;
        [SerializeField] private Text Magnitude;

        private DefaultSeparateThreadExecutor _executor;
        
        private void Awake()
        {
            _executor = new DefaultSeparateThreadExecutor();
        }

        public bool isValid
        {
            set => IsValid.text = value.ToString();
        }

        public float MagnitudeFloat
        {
            set => Magnitude.text = $"{value:0.00}"; 
        }

        private int chlen = 0;
        Ping ping = new Ping();
        private PingReply _reply;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _executor.Execute(() =>
                {
                    while(true)
                    {
                        try
                        {
                            if(_reply != null) continue;
                            _reply = ping.Send("8.8.8.8");
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e);
                        }
                    }
                }, () =>
                {
                    Debug.Log("COMPLETE");
                });
            }

            if (_reply == null) return;
            Debug.Log(_reply.RoundtripTime);
            _reply = null;
        }

        void Eblo(System.DateTime time)
        {
            Debug.Log(time.Second);
        }
    }
}
