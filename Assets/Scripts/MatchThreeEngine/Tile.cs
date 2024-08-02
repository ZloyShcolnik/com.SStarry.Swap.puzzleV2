using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace MatchThreeEngine
{
	public sealed class Tile : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler
	{
		public int x;
		public int y;

		public Image icon;

		public Button button;

		private TileTypeAsset _type;

		public TileTypeAsset Type
		{
			get => _type;

			set
			{
				if (_type == value) return;

				_type = value;

				icon.sprite = _type.sprite;
			}
		}

		private Board _board;
		private void Start()
		{
			_board=FindObjectOfType<Board>();
		}


		public TileData Data => new TileData(x, y, _type.id);
		
		public void OnPointerDown(PointerEventData eventData)
		{
			_board.Select(this);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_board.Select(Provider.LastEnteredTile);
		}
		
		public void OnPointerEnter(PointerEventData eventData)
		{
			Provider.LastEnteredTile = this;
		//	_board.Select(this);
		}
	}
}
