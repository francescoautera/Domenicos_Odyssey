using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Domenico.Shared
{
	public class ButtonsMover : MonoBehaviour
	{
		[SerializeField] private Ease ease;
		[SerializeField] private float jumpPower;
		[SerializeField] private float duration;

		[SerializeField] private RectTransform outOfScreenExitPoint;
		public RectTransform OutOfScreenExitPoint => outOfScreenExitPoint;

		[SerializeField] private RectTransform outOfScreenEnterPoint;
		public RectTransform OutOfScreenEnterPoint => outOfScreenEnterPoint;

		

		
		public void SwapButtons(ColorButton button1, ColorButton button2)
		{
			List<Vector3> endPositions = new List<Vector3>{ button1.rectTransform.position, button2.rectTransform.position };
			button1.rectTransform.DOJump(endPositions[1], jumpPower,1,duration).SetEase(ease);
			button2.rectTransform.DOJump(endPositions[0], -jumpPower,1,duration).SetEase(ease);
		}
		
		public void KickOutButton(ColorButton button)
		{
			var sequence = DOTween.Sequence();

			sequence.Append(button.rectTransform.DOMove(button.rectTransform.position + new Vector3(0, jumpPower, 0), .5f).SetEase(ease));
			sequence.AppendInterval(.7f);
			sequence.Append(button.rectTransform.DOMove(outOfScreenExitPoint.position, .5f).SetEase(ease));
			sequence.onComplete += () => Destroy(button.gameObject);
		}
	
		
		
		//NON HO LA MINIMA IDEA DEL PERCHÈ MA NON VA NEL PUNTO GIUSTO, VA SEMPRE AL CENTRO
		public void MakeButtonEntrance(Transform parent, GameObject placeholder, ColorButton button)
		{
			var sequence = DOTween.Sequence();

			var endPos = placeholder.GetComponent<RectTransform>().position;
			sequence.Append(button.rectTransform.DOMove(endPos + new Vector3(0, jumpPower, 0), .5f).SetEase(ease));
			sequence.AppendInterval(.7f);
			sequence.Append(button.rectTransform.DOMove(endPos, .5f).SetEase(ease));
			sequence.onComplete += () =>
			{
				Destroy(placeholder.gameObject);
				button.rectTransform.SetParent(parent);
			};
		}
	}
}