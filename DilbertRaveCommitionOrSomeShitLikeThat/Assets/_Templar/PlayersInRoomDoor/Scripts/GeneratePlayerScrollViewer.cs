
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
namespace Templar
{
    public class GeneratePlayerScrollViewer : UdonSharpBehaviour
    {
        public RectTransform buttonParent;
        public RectTransform buttonTemplate;
        public Color ColorBiasForUI = Color.white;
        public void GenerateUI(VRCPlayerApi[] playersInRoom)
        {
            // destroy any pre-existing buttons
            for (int i = 0; i < buttonParent.childCount; i++)
            {
                RectTransform tf = (RectTransform)buttonParent.GetChild(i);
                if (tf != buttonTemplate)
                    Destroy(tf.gameObject);
            }
            // measure the dimensions of the UI
            int len = playersInRoom.Length;
            float buttonHeight = buttonTemplate.sizeDelta.y;
            buttonParent.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight * len);
            // instantiate buttons
            for (int i = 0; i < len; i++)
            {
                // instantiate and transform the button
                GameObject newButton = VRCInstantiate(buttonTemplate.gameObject);
                RectTransform newButtonTf = newButton.GetComponent<RectTransform>();
                newButtonTf.SetParent(buttonParent);
                newButtonTf.localScale = Vector3.one;
                newButtonTf.localRotation = Quaternion.identity;
                newButtonTf.anchoredPosition3D = buttonHeight * i * Vector3.down;
                newButton.SetActive(true);

                // modify the button's data
                PlayerUITag buttonProgram = newButton.GetComponent<PlayerUITag>();
                buttonProgram._ConfigureButton(playersInRoom[i], ColorBiasForUI);
            }
        }
    }
}
